/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: This class handles the interactions of players and interactable objects in game.
 *
 * Weapons and items can be picked up from the game world.
 * Doing so drops whatever the player is currently holding to the ground.
 * Weapons are the only interactable objects currently
 */
using UnityEngine;
using Photon.Pun;

public class PickUpSystem : MonoBehaviourPun
{
    // const tags and flags for the pickup system
    private const string ItemTag = "Item";
    private const string WeaponTag = "Weapon";

    // editor exposed fields
    [SerializeField] private LayerMask pickUpsLayer;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform dropPoint;
    [SerializeField] private PlayerInputHandler playerInput;
    
    // private fields
    private PlayerStats _stats;

    private void Start()
    {
        // cache needed components
        _stats = GetComponent<PlayerStats>();
    }
    private void OnEnable()
    {
        playerInput.Interact += Interacted;
    }
    private void OnDisable()
    {
        playerInput.Interact -= Interacted;
    }

    private void Interacted()
    {
        photonView.RPC("InteractedRPC", RpcTarget.All);
    }
    
    //checks if there is an object to pickup within the range of the player and then calls pickup functions if so.
    [PunRPC]
    private void InteractedRPC()
    {
        Collider[] items = Physics.OverlapBox(transform.position, new Vector3(_stats.PickUpRange, 0f, _stats.PickUpRange), transform.rotation, pickUpsLayer);
        if(items.Length > 0)
        {
            foreach(Collider item in items)
            {
                if (item.gameObject.CompareTag(WeaponTag))
                {
                    DropCurrentWeapon();
                    PickupWeapon(item.gameObject);
                }
                else if(item.gameObject.CompareTag(ItemTag))
                {
                }   
            }
        }
    }

    // picks up a new weapon
    private void PickupWeapon(GameObject newWeapon)
    {
        _stats.CurrentWeapon = newWeapon;
        BoxCollider[] cols = newWeapon.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider col in cols)
        {
            col.enabled = false;
        }
        newWeapon.GetComponent<Rigidbody>().isKinematic = true;
        newWeapon.transform.parent = hand;
        newWeapon.transform.position = hand.position;
        newWeapon.transform.rotation = hand.rotation;
        newWeapon.GetComponent<WeaponFiring>().enabled = true;
        newWeapon.GetComponent<WeaponUIScript>().TurnOffUI();
    }
    
    // drops current weapon
    private void DropCurrentWeapon()
    {
        _stats.CurrentWeapon.GetComponent<WeaponFiring>().enabled = false;
        _stats.CurrentWeapon.transform.parent = null;
        _stats.CurrentWeapon.transform.position = dropPoint.transform.position;
        _stats.CurrentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        BoxCollider[] cols = _stats.CurrentWeapon.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider col in cols)
        {
            col.enabled = true;
        }
    }
}

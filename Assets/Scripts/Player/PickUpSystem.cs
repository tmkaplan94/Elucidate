/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: This class handles the interactions of players and interactable objects in game.
 *
 * Weapons and items can be picked up from the game world.
 * Doing so drops whatever the player is currently holding to the ground.
 * Items and Weapons are the only interactable objects currently
 * Has a lot of repeat code, need to convert it to templates to make things simpler.
 * Dependent on PlayerStats which is unnecessary, need to fix.
 */
using UnityEngine;
using Photon.Pun;

public class PickUpSystem : MonoBehaviourPun
{
    // const tags and flags for the pickup system
    private const string ItemTag = "Item";
    private const string WeaponTag = "Weapon";

    public delegate void TriggerUI(string objName);
    public event TriggerUI TriggeredUI;

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

    // notify the observer to display UI when in range of weapon
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(WeaponTag) && photonView.IsMine)
        {
            TriggeredUI(other.transform.parent.name);

        }
    }
    
    // notify the observer to turn off UI when leaving range of weapon
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(WeaponTag) && photonView.IsMine)
        {
            TriggeredUI(other.transform.parent.name);
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
        if(TriggeredUI != null && photonView.IsMine)
        {
            TriggeredUI("");
        }
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

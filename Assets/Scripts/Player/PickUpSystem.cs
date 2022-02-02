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

public class PickUpSystem : Subject
{
    // const tags and flags for the pickup system
    private const string ItemTag = "Item";
    private const string WeaponTag = "Weapon";
    private const int NotifyInteractUIOff = 0;
    private const int NotifyInteractUIOn = 1;
    private const int NotifyWeaponUI = 3;

    // editor exposed fields
    [SerializeField] private LayerMask pickUpsLayer;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform dropPoint;
    
    // private fields
    private PlayerStats _stats;
    private Transform _playerTransform;

    void Start()
    {
        // cache needed components
        _stats = GetComponent<PlayerStats>();
        _playerTransform = GetComponent<Transform>();
    }

    // enables player to interact/pickup item or weapon if in range
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Interact"))
        {
            if (other.transform.CompareTag(WeaponTag))
            {
                DropCurrentWeapon();
                PickupWeapon(other.transform.parent.gameObject);
            }
            else if (other.transform.CompareTag(ItemTag))
            {
                PickupItem(other.gameObject);
            }
        }
    }
    // notify the observer to display UI when in range of weapon
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(WeaponTag))
        {
            Notify(NotifyInteractUIOn);
        }
    }
    
    // notify the observer to turn off UI when leaving range of weapon
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(WeaponTag))
        {
            Notify(NotifyInteractUIOff);
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
        if (_notify != null)
        {
            Notify(NotifyWeaponUI);
        }
    }

    // picks up a new item
    private void PickupItem(GameObject newItem)
    {
        _stats.CurrentItem = newItem;

        newItem.GetComponent<BoxCollider>().enabled = false;
        newItem.GetComponent<Rigidbody>().isKinematic = true;
        newItem.transform.parent = hand;
        newItem.transform.position = hand.position;
        newItem.transform.rotation = hand.rotation;

    }

    // drops current item
    private void DropCurrentItem()
    {
        _stats.CurrentItem.transform.parent = null;
        _stats.CurrentItem.transform.position = dropPoint.position;
        _stats.CurrentItem.GetComponent<Rigidbody>().isKinematic = false;
        _stats.CurrentItem.GetComponent<BoxCollider>().enabled = true;
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
        Notify(NotifyInteractUIOff);
    }
}

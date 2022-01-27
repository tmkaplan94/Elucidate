using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * version: 0.8
 * Date: 1/12/2022
 * Description: This class handles the interactions of players and interactible objects in game.
 * Summary: Weapons and items can be picked up from the game world
 *          Doing so drops whatever the player is currently holding to the ground.
 * Notes: Items and Weapons are the only interactable objects currently
 *        
 * TODO: This class has a lot of repeat code, need to convert it to templates to make things simpler.
 * 
 * Author: Grant Reed
 * Contributers: Loc Trinh
 * 
 */
public class PickUpSystem : Subject
{
    private PlayerStats stats;
    private string itemTag = "Item";
    private string weaponTag = "Weapon";
    private Transform playerTransform;

    [SerializeField]
    private LayerMask pickUpsLayer;
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private Transform dropPoint;


    void Start()
    {
        stats = GetComponent<PlayerStats>();
        playerTransform = GetComponent<Transform>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Interact"))
        {
            if (other.transform.CompareTag(weaponTag))
            {
                DropCurrentWeapon();
                PickupWeapon(other.transform.parent.gameObject);
            }
            else if (other.transform.CompareTag(itemTag))
            {
                PickupItem(other.gameObject);
            }
        }
    }
	// When weapon get touched by player, notify the observer to display UI
	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag(weaponTag))
		{
			Notify(1);
		}
	}
	// When player leaves, notify the observer to turn off UI
	private void OnTriggerExit(Collider other)
	{
		if(other.transform.CompareTag(weaponTag))
		{
			Notify(0);
		}
	}
    
    private void PickupWeapon(GameObject newWeapon)
    {
        stats.CurrentWeapon = newWeapon;
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
    }

    private void PickupItem(GameObject newItem)
    {
        stats.CurrentItem = newItem;
        
        newItem.GetComponent<BoxCollider>().enabled = false;
        newItem.GetComponent<Rigidbody>().isKinematic = true;
        newItem.transform.parent = hand;
        newItem.transform.position = hand.position;
        newItem.transform.rotation = hand.rotation;
        
    }

    private void DropCurrentItem()
    {
        stats.CurrentItem.transform.parent = null;
        stats.CurrentItem.transform.position = dropPoint.position;
        stats.CurrentItem.GetComponent<Rigidbody>().isKinematic = false;
        stats.CurrentItem.GetComponent<BoxCollider>().enabled = true;
    }
    private void DropCurrentWeapon()
    {
        stats.CurrentWeapon.GetComponent<WeaponFiring>().enabled = false;
        stats.CurrentWeapon.transform.parent = null;
        stats.CurrentWeapon.transform.position = dropPoint.transform.position;
        stats.CurrentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        BoxCollider[] cols = stats.CurrentWeapon.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider col in cols)
        {
            col.enabled = true;
        }

    }
}

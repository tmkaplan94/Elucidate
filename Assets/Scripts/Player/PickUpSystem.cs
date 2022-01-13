using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * version: 1.0
 * Date: 1/12/2022
 * Description: This class handles the interactions of players and interactible objects in game.
 * Summary: Weapons and items can be picked up from the game world
 *          Doing so drops whatever the player is currently holding to the ground.
 * Notes: Items and Weapons are the only interactable objects currently
 * 
 * 
 * Author: Grant Reed
 * Contributers:
 * 
 */
public class PickUpSystem : MonoBehaviour
{
    PlayerStats stats;
    string itemTag = "Item";
    string weaponTag = "Weapon";
    [SerializeField]
    Transform hand;
    [SerializeField]
    Transform dropPoint;


    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(weaponTag))
        {
            if (Input.GetButtonDown("Interact"))
            {
                PickupWeapon(other.gameObject);
            }
        }
    }  
    
    private void PickupWeapon(GameObject newWeapon)
    {
        stats.EquipWeapon(newWeapon);
        newWeapon.transform.parent = hand;
    }

}

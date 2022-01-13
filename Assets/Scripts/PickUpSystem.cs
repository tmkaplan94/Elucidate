using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles the interactions of players and objects in game.
 * 
 * 
 * Author: Grant Reed
 * Date: 1/12/2022
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

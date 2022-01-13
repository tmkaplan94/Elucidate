using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 
 * This class holds all of the information about a player game object, such as health, move speed, current
 * weapons and items, etc.
 * 
 * Author: Grant Reed
 * Date: 1/12/2022
 */
public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float health;
    //These are serialized just for testing purposes.
    [SerializeField]
    GameObject currentWeapon;
    [SerializeField]
    GameObject item;

    [SerializeField]
    private float moveSpeed;
    
    
    public float MoveSpeed
    {
        get
        {
            return this.moveSpeed;
        }
        set
        {
            this.moveSpeed = value;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Kill();
        }
    }

    public void EquipWeapon(GameObject wep)
    {
        currentWeapon = wep;
    }

    void Kill()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * version 1.0
 * Date: 1/12/2022
 * Description: This class holds all of the information about a player game object, such as 
 *              health, move speed, current weapons and items, etc.
 * 
 * Notes: This class has getters and setters for each of its adjustable fields in game.
 *          This is how player states are actually changed in game.
 * Author: Grant Reed
 * Contributors:
 * 
 */
public class PlayerStats : MonoBehaviour, IDamageable<float>
{
    [SerializeField]
    private float health;
    //These are serialized just for testing purposes.
    
    private GameObject currentItem;
    [SerializeField]
    private GameObject currentWeapon;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float pickupRange;

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
    public GameObject CurrentWeapon
    {
        get
        {
            return this.currentWeapon;
        }
        set
        {
            this.currentWeapon = value;
        }
    }
    public GameObject CurrentItem
    {
        get
        {
            return this.currentItem;
        }
        set
        {
            this.currentItem = value;
        }
    }
    public float PickUpRange
    {
        get
        {
            return this.pickupRange;
        }
        set
        {
            this.pickupRange = value;
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

    public void Kill()
    {
        print("dead");
    }
}

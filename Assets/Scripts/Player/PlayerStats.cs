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
 *          There is a lot of communication between this class and many other classes about the player in game,
 *          This is the main 
 *        
 * TODO: A lot of change needs to happen with damage and pickups which will require a lot of
 *      change with how this class handles those things as well.
 *        
 * Author: Grant Reed
 * Contributors:
 * 
 */

public class PlayerStats : Subject, IDamageable<float>
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;

    private GameObject currentItem;
    [SerializeField]
    private GameObject currentWeapon;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float pickupRange;

    public float MaxHealth
    {
        get
        {
            return this.maxHealth;
        }
        set
        {
            this.maxHealth = value;
        }
    }
    public float Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }
    }
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

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Kill();
        }
        Notify((int)damage);
    }

    public void Kill()
    {
        print("dead");
    }
}

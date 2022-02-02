/*
 * Author: Grant Reed
 * Contributors:
 * Description: This class holds all the information about a player.
 *
 * This includes health, move speed, current weapon, current items, etc.
 * This class has getters and setters for each of its adjustable fields in game.
 * This is how player states are actually changed in game.
 * There is a lot of communication between this class and many other classes about the player in game.
 *        
 * TODO: Changing damage and pickups will require a lot of change with this class as well.
 */
using UnityEngine;

public class PlayerStats : Subject, IDamageable<float>
{
    // const tags and flags for the pickup system
    
    // editor exposed fields
    [SerializeField] private float maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pickupRange;
    [SerializeField] private GameObject currentWeapon;
    [SerializeField] private GameObject currentItem;
    
    // private fields
    private float _health;
    
    #region Properties
    
    public float MaxHealth
    { 
        get; set;
    }
    public float Health
    {
        get; set;
    }
    public float MoveSpeed
    {
        get; set;
    }
    public float PickUpRange
    {
        get; set;
    }
    public GameObject CurrentWeapon
    {
        get; set;
    }
    public GameObject CurrentItem
    {
        get; set;
    }

    #endregion
    
    private void Start()
    {
        _health = maxHealth;
    }

    // IDamagable method to decrement _health, calls Die() if _health reaches 0.
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0f)
        {
            Kill();
        }
        Notify((int)damage);
    }

    // IDamageable method to die if _health has reached 0.
    public void Kill()
    {
        Debug.Log("dead");
        GameEventBus.Publish(GameEvent.LOSS);
    }
}

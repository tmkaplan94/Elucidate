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
    // editor exposed fields
    [SerializeField] private float _health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pickupRange;
    [SerializeField] private GameObject currentWeapon;
    //[SerializeField] private GameObject currentItem;
    
    #region Properties
    
    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public float Health
    {
        get => _health;
        set => _health = value;
    }
    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    public float PickUpRange
    {
        get => pickupRange;
        set => pickupRange = value;
    }
    public GameObject CurrentWeapon
    {
        get => currentWeapon;
        set => currentWeapon = value;
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

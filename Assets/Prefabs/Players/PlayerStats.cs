using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    GameObject currentWeapon;
    [SerializeField]
    GameObject item;

    [SerializeField]
    private float moveSpeed;

    void Start()
    {
        
    }
    
    public float GetMoveSpeed()
    {
        return moveSpeed;
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

/*
 * Author: Brian Caballero
 * Contributors: Grant Reed
 * Description: 
 */
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Subject, IDamageable <float>
{
    // editor exposed fields
    
    // private fields
    
    public float currentHealth = 1;
    public float maxHealth = 1;
    public GameObject healthBarUI = null;
    public Slider healthSlider;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = CalculateHealth();
        GameEventBus.Publish(GameEvent.ENEMYADDED);
    }
    
    void Update()
    {
        
        healthSlider.value = CalculateHealth();
        if (currentHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Kill()
    {
        GameEventBus.Publish(GameEvent.ENEMYKILLED);
        Destroy(gameObject);
        Debug.Log("I died!");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
}

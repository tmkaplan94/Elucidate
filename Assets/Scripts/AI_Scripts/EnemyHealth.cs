using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable <float>
{
    public float currentHealth = 1;
    public float maxHealth = 1;

    public GameObject healthBarUI = null;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = CalculateHealth();


    }

    // Update is called once per frame
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

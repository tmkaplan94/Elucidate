/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Displays and updates enemy health above their heads.
 */
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable <float>
{
    // editor exposed fields
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject healthBarUI;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private RobotStats stats;
    
    // private fields
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
        healthSlider.value = CalculateHealth();

        GameEventBus.EnemyAdded?.Invoke();
    }
    
    private void Update()
    {
        
        healthSlider.value = CalculateHealth();
        if (_currentHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        
        if (_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }
    }

    // IDamagable method to decrement _health, calls Die() if _health reaches 0.
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }
    
    //  method to die if _health has reached 0.
    private void Kill()
    {
        GameEventBus.EnemyKilled?.Invoke();
        
        Destroy(gameObject);
        Debug.Log("I died!");
    }

    // Calculate and return health.
    private float CalculateHealth()
    {
        if (maxHealth != 0)
        {
            return _currentHealth / maxHealth;
        }

        return 0.0f;
    }
}

/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Displays and updates enemy health above their heads.
 */
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RobotController))]
public class RobotHealth : MonoBehaviour, IDamageable <float>
{
    // editor exposed fields
    [SerializeField] private GameObject healthUI;

    // private fields
    private RobotController _robotController;
    private float _currentHealth;
    private Slider _healthSlider;

    private void Start()
    {
        _robotController = GetComponent<RobotController>();
        _currentHealth = _robotController.Stats.MaxHealth;
        _healthSlider = healthUI.GetComponentInChildren<Slider>();
        _healthSlider.value = CalculateHealth();

        GameEventBus.EnemyAdded?.Invoke();
    }
    
    private void Update()
    {
        
        _healthSlider.value = CalculateHealth();
        if (_currentHealth < _robotController.Stats.MaxHealth)
        {
            healthUI.SetActive(true);
        }
        
        if (_currentHealth > _robotController.Stats.MaxHealth)
        {
            _currentHealth = _robotController.Stats.MaxHealth;
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
        if (_robotController.Stats.MaxHealth != 0)
        {
            return _currentHealth / _robotController.Stats.MaxHealth;
        }

        return 0.0f;
    }
}

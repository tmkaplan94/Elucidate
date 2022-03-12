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
    // private fields
    private RobotController _robotController;
    private GameObject _healthUI;
    private float _currentHealth;
    private Slider _healthSlider;

    // gets needed values, abstracted away from designer
    private void Start()
    {
        _robotController = GetComponent<RobotController>();
        _healthUI = transform.GetChild(0).gameObject;
        _currentHealth = _robotController.Stats.MaxHealth;
        _healthSlider = _healthUI.transform.GetChild(0).GetComponent<Slider>();
        _healthSlider.value = CalculateHealth();

        GameEventBus.EnemyAdded?.Invoke();
    }
    
    private void Update()
    {
        
        _healthSlider.value = CalculateHealth();
        if (_currentHealth < _robotController.Stats.MaxHealth)
        {
            _healthUI.SetActive(true);
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

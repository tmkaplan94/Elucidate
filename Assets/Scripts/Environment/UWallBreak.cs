/*
 * Author: Alex Pham
 * Contributors:
 * Description: Provides health stat to unbreakable wall.
 */
using UnityEngine;

public class UWallBreak : MonoBehaviour, IDamageable <float>
{
    // editor exposed fields
    [SerializeField] private float maxHealth;
    
    // private fields
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    // IDamagable method must be implemented, even if it does nothing
    public void TakeDamage(float dmg) { }

    // IDamageable method to destroy game object
    public void Kill()
    {
        Destroy(gameObject);
    }
}

/*
 * Author: Alex Pham
 * Contributors:
 * Description: Provides health stat to breakable wall.
 */
using UnityEngine;
using Random = UnityEngine.Random;

public class WallBreak : MonoBehaviour, IDamageable <float>
{
    // editor exposed fields
    [SerializeField] private float maxHealth;
    [SerializeField] private float minHealth;
    [SerializeField] private GameObject wallShattered;
    
    // private fields
    private float _currentHealth;
    
    private void Start()
    {
        _currentHealth = maxHealth;
        
        //get a random number from 20 to 35 for wall health
        maxHealth = Random.Range(minHealth, maxHealth);
        _currentHealth = maxHealth;
    }

    // IDamagable method to decrement _currentHealth, calls Die() if _health reaches 0.
    public void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    // IDamageable method to break wall if _health has reached 0.
    public void Kill()
    {
        gameObject.SetActive(false);
        Vector3 temp = transform.position;
        Vector3 boxScale = transform.localScale;
        Vector3 scaleFactor = new Vector3(.5f, .5f, .5f);
        wallShattered.transform.localScale = Vector3.Scale(boxScale, scaleFactor);
        temp.y -= .15f;
        Instantiate(wallShattered, temp, transform.rotation);
        GetComponent<Rigidbody>().AddExplosionForce(50f,temp, 4f);
        Destroy(gameObject);
    }
}

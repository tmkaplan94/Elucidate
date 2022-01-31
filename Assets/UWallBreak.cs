using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UWallBreak : MonoBehaviour, IDamageable <float>
{
    public float currHealth = 1;
    public float maxHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}

/*
 * Author: Grant Reed
 * Contributors:
 * Description: Damages IDamageable objects and destroys itself.
 */

using System.Collections;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    private float damage;
    
    // properties
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamageable<float>>().TakeDamage(damage);
        Destroy(this.gameObject);
    }
    public void KillAfterTime(float lifetime)
    {
        Destroy(this.gameObject, lifetime);
    }  
}

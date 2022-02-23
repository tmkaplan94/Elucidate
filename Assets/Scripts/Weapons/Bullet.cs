/*
 * Author: Grant Reed
 * Contributors: Tyler Kaplan
 * Description: Damages IDamageable objects and destroys itself.
 */

using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    // properties
    public float Damage { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamageable<float>>().TakeDamage(Damage);
        Destroy(gameObject);
    }
    public void KillAfterTime(float lifetime)
    {
        Destroy(gameObject, lifetime);
    }  
}

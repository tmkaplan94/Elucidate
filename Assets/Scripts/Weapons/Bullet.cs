/*
 * Author: Grant Reed
 * Contributors:
 * Description: Damages IDamageable objects and destroys itself.
 */

using System.Collections;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
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
            PhotonNetwork.Destroy(gameObject);
    }
    public void KillAfterTime(float lifetime)
    {
        StartCoroutine(KillAfterLifeTime(lifetime));
    }
    private IEnumerator KillAfterLifeTime(float lifetime)
    {
        yield return new WaitForSecondsRealtime(lifetime);
        PhotonNetwork.Destroy(gameObject);
    }
    
}

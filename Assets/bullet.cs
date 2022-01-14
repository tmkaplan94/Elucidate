using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerStats>().TakeDamage(damage);
        Destroy(gameObject);
    }
}

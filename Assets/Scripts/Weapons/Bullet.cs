/*
 * Author: Grant Reed
 * Contributors:
 * Description: Damages IDamageable objects and destroys itself.
 */

using System.Runtime.CompilerServices;
using UnityEngine;
//using Photon.Pun;

public class Bullet : MonoBehaviour
{
    // editor exposed fields
    [SerializeField] private float damage;

    // private fields
    //private PhotonView _view;
    
    // properties
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    // private void Start()
    // {
    //     _view = GetComponent<PhotonView>();
    // }
    
    private void OnTriggerEnter(Collider other)
    {
        // if (view.IsMine)
        //{
            other.GetComponent<IDamageable<float>>().TakeDamage(damage);
            Destroy(gameObject);
        //}
    }
    
}

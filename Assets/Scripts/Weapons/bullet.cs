using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
 * version 1.0
 * Date: 1/13/2022
 * Description: This class currently just damages idamageable objects.
 * 
 * Notes: I presume this script will be completely overhalled. For now, it works.
 * Author: Grant Reed
 * Contributors:
 * 
 */
public class bullet : MonoBehaviour
{
    public float damage;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (view.IsMine)
        {
            other.GetComponent<IDamageable<float>>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

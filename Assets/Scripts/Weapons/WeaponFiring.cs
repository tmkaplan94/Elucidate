using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * version 1.0
 * Date: 1/13/2022
 * Description: This class handles the instantiating of bullets and accelerating them.
 * 
 * Notes: I presume this script will likely be overhaulled completely once the damage system
 *          is decided on and complete.
 * Author: Grant Reed
 * Contributors:
 * 
 */
public class WeaponFiring : MonoBehaviour
{

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletSpeed;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * bulletSpeed);
        Destroy(newBullet, 2.0f);
    }
}

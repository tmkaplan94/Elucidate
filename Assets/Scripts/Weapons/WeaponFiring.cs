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
 * Contributors: Loc Trinh
 * 
 * EDIT: Now is able to emit muzzleflash when a weapon shoots.
 */
public class WeaponFiring : MonoBehaviour
{

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    public float lightRange = 10.0f;
    [SerializeField]
    public float lightIntensity = 2.0f;
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
        muzzleFlash();
        Destroy(newBullet, 0.5f);
    }

    private void muzzleFlash()
    {
        GameObject newLight = new GameObject("Muzzle Flash");
        Light lightComp = newLight.AddComponent<Light>();
        lightComp.type = LightType.Point;
        lightComp.color = Color.yellow;
        lightComp.range = lightRange;
        lightComp.intensity = lightIntensity;
        newLight.transform.position = firePoint.position;
        Destroy(newLight, 0.1f);
    }
}

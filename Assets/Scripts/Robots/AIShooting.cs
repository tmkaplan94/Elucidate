using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : MonoBehaviour
{
    [SerializeField]
    private AIStats stats;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private float BulletSpeed = 1000f;
    private float ShootingCount = 0;
    public void Fire()//Made to have a specific firerate
    {
        if (ShootingCount >= stats.ShootingSpeed)
        {
            Shoot();
            ShootingCount = 0;
        }
        ShootingCount += 1;
    }
    void Shoot()//Actually fires teh bullet, Code made by Grant.
    {
        GameObject newBullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * BulletSpeed);
        Destroy(newBullet, 2.0f);
    }
}

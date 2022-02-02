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
    private PlayAudioSource _audio;


    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.GetComponent<PlayAudioSource>();
    }

    public void Fire()
    {
        if (ShootingCount >= stats.ShootingSpeed)
        {
            Shoot();
            ShootingCount = 0;
        }
        ShootingCount += 1;
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * BulletSpeed);
        Destroy(newBullet, 2.0f);
        _audio.Play();
    }
}

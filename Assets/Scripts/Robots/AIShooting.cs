/*
 * Author: Brian Caballero
 * Contributors:
 * Description: Deals with enemy shooting.
 */
using UnityEngine;

[RequireComponent(typeof(PlayAudioSource))]
public class AIShooting : MonoBehaviour
{
    // editor exposed fields
    [SerializeField] private AIStats stats;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    
    // private fields
    private Transform _firePoint;
    private PlayAudioSource _audio;
    private float _shootingCount;

    private void Start()
    {
        _firePoint = transform.GetChild(3).GetChild(0).transform;
        _audio = gameObject.GetComponent<PlayAudioSource>();
        _shootingCount = 0;
    }

    // regulates shooting speed
    public void Fire()
    {
        if (_shootingCount >= stats.shootingSpeed)
        {
            Shoot();
            _shootingCount = 0;
        }
        _shootingCount += 1;
    }

    // instantiates a projectile, adds a force, and plays a sound
    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, _firePoint.position, _firePoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * bulletSpeed);
        Destroy(newBullet, 2.0f);
        _audio.Play();
    }
}

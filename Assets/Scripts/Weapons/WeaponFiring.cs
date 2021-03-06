/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: Instantiates and propels bullets.
 * 
 * Has basic firing functionality and muzzle flash for light effects.
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Photon.Pun;

public class WeaponFiring : MonoBehaviourPun
{
    // editor exposed fields
    [SerializeField] private Transform firePoint;
    [SerializeField] private Weapon weaponType;
    

    // private fields
    private PlayAudioSource _audio;
    private float _nextFireTime;

    private void Start()
    {
        _audio = GetComponent<PlayAudioSource>();
        _nextFireTime = 0.0f;
    }

    public void TryShoot()
    {
        if (Time.time >= _nextFireTime)
        {
            Shoot();
            // sets the next time the player is able to shoot based on rounds per second.
            _nextFireTime = Time.time + 1.0f / weaponType.RoundsPerSecond;
        }
    }

    // shoots bullet
    private void Shoot()
    {
        GameObject newBullet = Instantiate(weaponType.Bullet, firePoint.position, firePoint.rotation);
        newBullet.transform.localScale *= weaponType.BulletSizeScale;
        newBullet.GetComponent<Bullet>().Damage = weaponType.BulletDamage;
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * weaponType.BulletVelocity);
        newBullet.GetComponent<Bullet>().KillAfterTime(weaponType.BulletLifeTime);
        MuzzleFlash();
        _audio.Play();
    }

    // The MuzzleFlash method will create a muzzle flash object emitting a yellow light at the location the gun shoots briefly, then destroy itself. 
    private void MuzzleFlash()
    {
        GameObject muzzle = new GameObject("Muzzle Flash");
        Light muzzleFlashLight = muzzle.AddComponent<Light>();
        muzzleFlashLight.type = weaponType.MuzzleFlashLightType;
        muzzleFlashLight.color = weaponType.MuzzleFlashColor;
        muzzleFlashLight.range = weaponType.MuzzleFlashRange;
        muzzleFlashLight.intensity = weaponType.MuzzleFlashIntensity;
        muzzleFlashLight.transform.position = firePoint.position;
        Destroy(muzzle, weaponType.MuzzleFlashLifeTime);
    }
}

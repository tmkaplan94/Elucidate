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
    private float _reloadTime = 2.0f;
    private bool isReloading = false;
    private float _magazineSize;
    private float _magazineCurrent;

    public float MagazineSize
    {
        get => _magazineSize;
        set => _magazineSize = value;
    }
    public float MagazineCurrent
    {
        get => _magazineCurrent;
        set => _magazineCurrent = value;
    }
    private void OnEnable()
    {
        isReloading = false;
        _magazineSize = weaponType.Ammo;
        _magazineCurrent = _magazineSize;
        GameEventBus.Reloaded?.Invoke();
    }

    private void Start()
    {
        _audio = GetComponent<PlayAudioSource>();
        _nextFireTime = 0.0f;
    }

    public void TryShoot()
    {
        // BUG
        if(isReloading)
            return;
        if(_magazineCurrent <= 0)
            {
                StartCoroutine(Reload());
                return;
            }
        if (Time.time >= _nextFireTime)
        {
            Debug.Log("Before Shoot; Ammo = " + _magazineCurrent);
            Shoot();
            // sets the next time the player is able to shoot based on rounds per second.
            _nextFireTime = Time.time + 1.0f / weaponType.RoundsPerSecond;
        }
    }

    // shoots bullet
    private void Shoot()
    {
        _magazineCurrent--;
        GameEventBus.Shoot?.Invoke();
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

    private IEnumerator Reload()
    {
        if(photonView.IsMine)
        {
            isReloading = true;
            GameEventBus.Reloading?.Invoke();
            yield return new WaitForSeconds(_reloadTime); // Wait for duration of _reloadTime before refilling magazine.
            _magazineCurrent = _magazineSize;
            GameEventBus.Reloaded?.Invoke();
            isReloading = false;
        }
    }
}

/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: Instantiates and propels bullets.
 * 
 * Has basic firing functionality and muzzle flash for light effects.
 */
using UnityEngine;
//using Photon.Pun;

public class WeaponFiring : MonoBehaviour
{
    // editor exposed fields
    [SerializeField] private Transform firePoint;
    [SerializeField] private Weapon weaponType;

    // private fields
    private PlayAudioSource _audio;
    private float _nextFireTime;
    // private PhotonView view;

    // private void OnEnable()
    // {
    //     //view = GetComponentInParent<PhotonView>();   
    // }
    
    private void Start()
    {
        _audio = GetComponent<PlayAudioSource>();
        _nextFireTime = 0.0f;
    }

    void Update()
    {
        /*if (view.IsMine)
        {*/
        
        if (Input.GetButton("Fire1") && Time.time >= _nextFireTime)
        {
            Shoot();
            // converts rounds per minute to fire rate per second.
            _nextFireTime = Time.time + 1.0f / (weaponType.rpm / 60.0f);
        }
        
        //}
    }

    // shoots bullet
    private void Shoot()
    {
        GameObject newBullet = /*PhotonNetwork.*/Instantiate(weaponType.bullet, firePoint.position, firePoint.rotation);
        newBullet.transform.localScale *= weaponType.bulletSizeScale;
        newBullet.GetComponent<Bullet>().Damage = weaponType.bulletDamage;
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * weaponType.bulletVelocity);
        muzzleFlash();
        _audio.Play();
        Destroy(newBullet, 2.0f);
    }
    
    // The muzzleFlash method will create a muzzle flash object emitting a yellow light at the location the gun shoots briefly, then destroy itself. 
    private void muzzleFlash()
    {
        GameObject muzzle = new GameObject("Muzzle Flash");
        Light muzzleFlashLight = muzzle.AddComponent<Light>();
        muzzleFlashLight.type = weaponType.muzzleFlashLightType;
        muzzleFlashLight.color = weaponType.muzzleFlashColor;
        muzzleFlashLight.range = weaponType.muzzleFlashRange;
        muzzleFlashLight.intensity = weaponType.muzzleFlashIntensity;
        muzzleFlashLight.transform.position = firePoint.position;
        Destroy(muzzle, 0.1f);
    }
}

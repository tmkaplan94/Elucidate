using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;
/**
 * version 1.1
 * Date: 1/13/2022
 * Description: This class handles the instantiating of bullets and accelerating them.
 * 
 * Notes: 1.0 Added basic firing functionality.
 * 1.1 added basic network behavior to be improved on as well as scriptable object compatibility.
 * EDIT: Added muzzle flash for light effect
 * Edit: made muzzle flash use scriptable object values.
 *        
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * 
 */
public class WeaponFiring : MonoBehaviour
{

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private Weapon weaponType;
    [SerializeField]
    private PlayAudioSource playAudio;

    // private PhotonView view;
    private float nextFireTime = 0.0f;

    void Update()
    {
        /*if (view.IsMine)
        {*/
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            //converts rounds per minute to fire rate per second.
            nextFireTime = Time.time + 1.0f / (weaponType.rpm / 60.0f);
        }
        //}
    }
    private void OnEnable()
    {
        //view = GetComponentInParent<PhotonView>();   
    }
    private void Shoot()
    {
        GameObject newBullet = /*PhotonNetwork.*/Instantiate(weaponType.bullet, firePoint.position, firePoint.rotation);
        newBullet.transform.localScale *= weaponType.bulletSizeScale;
        newBullet.GetComponent<bullet>().damage = weaponType.bulletDamage;
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * weaponType.bulletVelocity);
        muzzleFlash();
        playAudio.Play();
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

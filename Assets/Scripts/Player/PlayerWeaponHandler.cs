using Photon.Pun;
using UnityEngine;

/*
 * Author: Grant Reed
 * Contributors: 
 * Description: This class ensures that the player's current weapon is up to date with player stats and handles
 *              weapon firing by calling the currrent weapon's shoot function.
 *              It listens to playerinputhandler's events and behaves appropriately.
 */
public class PlayerWeaponHandler : MonoBehaviourPun
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private PlayerInputHandler playerInput;
    private WeaponFiring currentWeapon;

    private void Start()
    {
        UpdateCurrentWeapon();
    }

    private void OnEnable()
    {
        playerInput.Shoot += Shoot;
        playerInput.CheckInteract += UpdateCurrentWeapon;
    }
    private void OnDisable()
    {
        playerInput.Shoot -= Shoot;
        playerInput.CheckInteract -= UpdateCurrentWeapon;
    }

    private void UpdateCurrentWeapon()
    {
        photonView.RPC("UpdateCurrentWeaponRPC", RpcTarget.All);
    }

    [PunRPC]
    private void UpdateCurrentWeaponRPC()
    {
        currentWeapon = _stats.CurrentWeapon.GetComponent<WeaponFiring>();
    }
    private void Shoot()
    {
        photonView.RPC("ShootRPC", RpcTarget.All);
    }
    [PunRPC]
    private void ShootRPC()
    {
        if(currentWeapon)
            currentWeapon.TryShoot();
    }
}

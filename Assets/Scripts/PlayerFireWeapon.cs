using Photon.Pun;
using UnityEngine;

public class PlayerFireWeapon : MonoBehaviourPun
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

    public void UpdateCurrentWeapon()
    {
        photonView.RPC("UpdateCurrentWeaponRPC", RpcTarget.All);
    }

    [PunRPC]
    public void UpdateCurrentWeaponRPC()
    {
        currentWeapon = _stats.CurrentWeapon.GetComponent<WeaponFiring>();
    }
    public void Shoot()
    {
        photonView.RPC("ShootRPC", RpcTarget.All);
    }
    [PunRPC]
    private void ShootRPC()
    {
        currentWeapon.tryShoot();
    }
}

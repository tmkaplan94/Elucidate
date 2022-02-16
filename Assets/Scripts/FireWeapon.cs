
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] private PlayerStats _stats;
    private WeaponFiring currentWeapon;

    private void Start()
    {
        UpdateCurrentWeapon();
    }
    public void UpdateCurrentWeapon()
    {
        currentWeapon = _stats.CurrentWeapon.GetComponent<WeaponFiring>();
    }
    public void Shoot()
    {
        currentWeapon.tryShoot();
    }
}

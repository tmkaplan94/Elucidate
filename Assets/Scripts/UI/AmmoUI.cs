using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class AmmoUI : MonoBehaviourPun
{
    [SerializeField] private WeaponFiring _wep;
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private Image _magazine;

    private GameObject _reloadUI;
    private void OnEnable()
    {
        _reloadUI = _stats.CurrentWeapon.transform.Find("WepUICanvas/Reloading...").gameObject;
        _reloadUI.SetActive(false);
        GameEventBus.Shoot += AmmoDepreciate;
        GameEventBus.Reloaded += AmmoRefill;
        GameEventBus.Reloading += currentlyReloading;
        GameEventBus.Reloaded += finishedReloading;
    }
    
    private void OnDisable()
    {
        GameEventBus.Shoot -= AmmoDepreciate;
        GameEventBus.Reloaded -= AmmoRefill;
        GameEventBus.Reloading -= currentlyReloading;
        GameEventBus.Reloaded -= finishedReloading;
    }
    private void AmmoDepreciate()
    {
        _magazine.fillAmount = _wep.MagazineCurrent/_wep.MagazineSize;
    }

    private void AmmoRefill()
    {
        _magazine.fillAmount = 1.0f;
    }
    private void currentlyReloading()
    {
        //GameObject _reloadUI = _stats.CurrentWeapon.transform.Find("WepUICanvas/Reloading...").gameObject;
        _reloadUI.SetActive(true);
    }

    private void finishedReloading()
    {
        //GameObject _reloadUI = _stats.CurrentWeapon.transform.Find("WepUICanvas/Reloading...").gameObject;
        _reloadUI.SetActive(false);
        
    }

}

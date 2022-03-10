using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    private Image _magazine;

    private void Awake()
    {
        _magazine = GetComponent<Image>();
    }

    private void OnEnable()
    {
        GameEventBus.Shoot += AmmoDepreciate;
        GameEventBus.Reloaded += AmmoRefill;
    }
    
    private void OnDisable()
    {
        GameEventBus.Shoot -= AmmoDepreciate;
        GameEventBus.Reloaded -= AmmoRefill;
    }
    private void AmmoDepreciate()
    {
        _magazine.fillAmount = WeaponFiring._magazineCurrent/WeaponFiring._magazineSize;
    }

    private void AmmoRefill()
    {
        _magazine.fillAmount = 1.0f;
    }


}

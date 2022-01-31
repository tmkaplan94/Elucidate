using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurWepUIObserver : Observer
{
    [SerializeField] private PlayerStats stats;

    private TextMeshProUGUI text;
    
    private const int notify_WeaponUI = 3;
    private void OnEnable()
    {
        uiSubject._notify += WhenNotified;
        text = GetComponentInChildren<TextMeshProUGUI>();
        WhenNotified(notify_WeaponUI);
    }
     
    private void OnDisable()
    {
        uiSubject._notify -= WhenNotified;
    }

    public override void WhenNotified(int val)
    {
        if(val == notify_WeaponUI)
        {
            text.text = stats.CurrentWeapon.name;
        }     
    }
}

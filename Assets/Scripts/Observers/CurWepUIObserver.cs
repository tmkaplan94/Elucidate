using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using TMPro;
/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: Updates UI for the current weapon of the player.
 *              listens to PickUpSystem.notify.
 */
public class CurWepUIObserver : Observer
{
    //gets information from playerstats
    [SerializeField] private PlayerStats stats;
    private TextMeshProUGUI text;
    
    //int for the event to listen to
    private const int notify_WeaponUI = 3;

    //subscribe on disable
    private void OnEnable()
    {
        uiSubject._notify += WhenNotified;
        text = GetComponentInChildren<TextMeshProUGUI>();
        WhenNotified(notify_WeaponUI);
    }
     //unsubscribe on disable
    private void OnDisable()
    {
        uiSubject._notify -= WhenNotified;
    }

    //updates ui text when subject calls Notify.
    public override void WhenNotified(int val)
    {
        if(val == notify_WeaponUI)
        {
            text.text = stats.CurrentWeapon.name;
        }     
    }
}

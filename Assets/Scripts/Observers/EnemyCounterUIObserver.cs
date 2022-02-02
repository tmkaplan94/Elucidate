using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounterUIObserver : Observer
{
    GameObject[] enemies;
    private TextMeshProUGUI text;
    private const int notify_EnemyUI = 2;
    
    private void OnEnable()
    {
        uiSubject._notify += WhenNotified;
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
     
    private void OnDisable()
    {
        uiSubject._notify -= WhenNotified;
    }

    public override void WhenNotified(int val)
    {
        if(val == notify_EnemyUI)
        { 
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            text.text = "Enemies: " + enemies.Length.ToString();
        }     
    }
}

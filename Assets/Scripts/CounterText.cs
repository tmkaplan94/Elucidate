using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterText : MonoBehaviour
{
    [SerializeField] private RobotSpecialList RobotList;
    private TextMeshProUGUI TMPtext;
    
    private void OnEnable()
    {
        GameEventBus.Subscribe(GameEvent.ENEMYKILLED, UpdateText);
        TMPtext = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText();
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameEvent.ENEMYKILLED, UpdateText);
    }

    private void UpdateText()
    {
        TMPtext.text = "Enemies: " + RobotList.Count();
    }
}

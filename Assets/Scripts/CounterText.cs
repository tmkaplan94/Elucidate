using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterText : MonoBehaviour
{
    private TextMeshProUGUI TMPtext;
    private int enemyCount = 0;
    
    private void OnEnable()
    {
        GameEventBus.Subscribe(GameEvent.ENEMYKILLED, SubtractCount);
        GameEventBus.Subscribe(GameEvent.ENEMYADDED, AddCount);
        TMPtext = GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameEvent.ENEMYKILLED, UpdateText);
        GameEventBus.Unsubscribe(GameEvent.ENEMYADDED, UpdateText);
    }

    private void AddCount()
    {
        enemyCount++;
        UpdateText();
    }
    private void SubtractCount()
    {
        enemyCount--;
        UpdateText();
        if(enemyCount <= 0)
        {
            GameEventBus.Publish(GameEvent.WIN);
        }
    }

    private void UpdateText()
    {
        TMPtext.text = "Enemies: " + enemyCount;
    }
}

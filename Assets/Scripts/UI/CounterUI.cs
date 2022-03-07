/*
 * Author: Loc Trinh
 * Contributors: 
 * Description: Small script that handles counter UI for remaining players/AIs.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    private TextMeshProUGUI _counterText;
    [SerializeField] GameObject UIvisible;

    void Awake()
    {
        _counterText = GetComponent<TextMeshProUGUI>();
        _counterText.text = "AI Remaining: " + GameManager.EnemyCount.ToString();
    }

    void OnEnable()
    {
        GameEventBus.EnemyKilled += counter;
        GameEventBus.PlayerAdded += counterSet;
    }

    void OnDisable()
    {
        GameEventBus.EnemyKilled -= counter;
        GameEventBus.PlayerAdded -= counterSet;
    }

    private void counter()
    {
        _counterText.text = "AI Remaining: " + GameManager.EnemyCount.ToString();
    }

    private void counterSet(int _id, PlayerStats _stats)
    {
        if(GameManager._isMultiplayer)
        {
            UIvisible.SetActive(false);
        }
    }
}

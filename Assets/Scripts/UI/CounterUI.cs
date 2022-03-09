/*
 * Author: Loc Trinh
 * Contributors: Grant Reed
 * Description: Small script that handles counter UI for remaining players/AIs.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    private TextMeshProUGUI _counterText;
    [SerializeField] private GameObject UIVisible;

    void Awake()
    {
        _counterText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        GameEventBus.EnemyKilled += counter;
        GameEventBus.PlayerAdded += counterSet;
        GameEventBus.EnemyAdded += counter;
    }

    void OnDisable()
    {
        GameEventBus.EnemyKilled -= counter;
        GameEventBus.PlayerAdded -= counterSet;
        GameEventBus.EnemyAdded -= counter;
    }

    private void counter()
    {
        _counterText.text = "AI Remaining: " + GameManager.EnemyCount.ToString();
    }

    private void counterSet(int _id, PlayerStats _stats)
    {
        if(GameManager._isMultiplayer)
        {
            UIVisible.SetActive(false);
        }
    }
}

/*
 * Author: Loc Trinh
 * Contributors: Tyler Kaplan, Grant Reed
 * Description: Displays the number of enemies remaining on the screen.
 */
using UnityEngine;
using TMPro;

public class CounterText : MonoBehaviour
{
    // private fields
    private TextMeshProUGUI _textMeshProText;
    private int _enemyCount;
    
    // subscribe to enemy added/killed events to add/subtract their count
    private void OnEnable()
    {
        _textMeshProText = GetComponent<TextMeshProUGUI>();
        _enemyCount = 0;

        GameEventBus.EnemyAdded += AddCount;
        GameEventBus.EnemyKilled += SubtractCount;
    }

    // unsubscribe from enemy added/killed events
    private void OnDisable()
    {
        GameEventBus.EnemyAdded -= AddCount;
        GameEventBus.EnemyKilled -= SubtractCount;
    }

    // add to enemy count
    private void AddCount()
    {
        _enemyCount++;
        UpdateText();
    }
    
    // subtracts from enemy count
    private void SubtractCount()
    {
        _enemyCount--;
        UpdateText();
        if(_enemyCount <= 0)
        {
            GameEventBus.Win?.Invoke();
        }
    }

    // updates displayed text
    private void UpdateText()
    {
        _textMeshProText.text = "Enemies: " + _enemyCount;
    }
}

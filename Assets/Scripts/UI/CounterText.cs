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
        GameEventBus.Subscribe(GameEvent.ENEMYKILLED, SubtractCount);
        GameEventBus.Subscribe(GameEvent.ENEMYADDED, AddCount);
    }

    // unsubscribe from enemy added/killed events
    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameEvent.ENEMYKILLED, UpdateText);
        GameEventBus.Unsubscribe(GameEvent.ENEMYADDED, UpdateText);
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
            GameEventBus.Publish(GameEvent.WIN);
        }
    }

    // updates displayed text
    private void UpdateText()
    {
        _textMeshProText.text = "Enemies: " + _enemyCount;
    }
}

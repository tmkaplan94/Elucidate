/*
 * Author: Tyler Kaplan
 * Contributors: Grant Reed
 * Description: GameManager controls and maintains the flow of the game.
 *
 * GameManager extends Singleton, which extends MonoBehavior.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private static GameEvent _currentStatus;
    public static GameEvent CurrentStatus()
    {
        return _currentStatus;
    }

    // subscribe all event functions to game events
    private void OnEnable()
    {
        GameEventBus.Subscribe(GameEvent.TITLE, TitleEvent);
        GameEventBus.Subscribe(GameEvent.COUNTDOWN, CountdownEvent);
        GameEventBus.Subscribe(GameEvent.START, StartEvent);
        GameEventBus.Subscribe(GameEvent.PAUSE, PauseEvent);
        GameEventBus.Subscribe(GameEvent.RESUME, ResumeEvent);
        GameEventBus.Subscribe(GameEvent.WIN, WinEvent);
        GameEventBus.Subscribe(GameEvent.LOSS, LossEvent);
        GameEventBus.Subscribe(GameEvent.QUIT, QuitEvent);
    }

    // initially set the game status
    private void Start()
    {
        _currentStatus = GameEvent.TITLE;
        Debug.Log("Current game status: " + _currentStatus);
    }

    // unsubscribe all event functions fromk game events
    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameEvent.TITLE, TitleEvent);
        GameEventBus.Unsubscribe(GameEvent.COUNTDOWN, CountdownEvent);
        GameEventBus.Unsubscribe(GameEvent.START, StartEvent);
        GameEventBus.Unsubscribe(GameEvent.PAUSE, PauseEvent);
        GameEventBus.Unsubscribe(GameEvent.RESUME, ResumeEvent);
        GameEventBus.Unsubscribe(GameEvent.WIN, WinEvent);
        GameEventBus.Unsubscribe(GameEvent.LOSS, LossEvent);
        GameEventBus.Unsubscribe(GameEvent.QUIT, QuitEvent);
    }

    // event functions update the current game status and dictate the behaviors that happen on event
    #region Private Event Functions

    private void TitleEvent()
    {
        _currentStatus = GameEvent.TITLE;
        SceneManager.LoadScene(0);
        Debug.Log("Current game status: " + _currentStatus);
    }
    
    private void CountdownEvent()
    {
        _currentStatus = GameEvent.COUNTDOWN;
        Debug.Log("Current game status: " + _currentStatus);
    }
    
    private void StartEvent()
    {
        _currentStatus = GameEvent.START;
        SceneManager.LoadScene(1);

        Debug.Log("Current game status: " + _currentStatus);
    }

    private void PauseEvent()
    {
        _currentStatus = GameEvent.PAUSE;
        Debug.Log("Current game status: " + _currentStatus);
    }
    
    private void ResumeEvent()
    {
        _currentStatus = GameEvent.RESUME;
        Debug.Log("Current game status: " + _currentStatus);
    }
    
    private void WinEvent()
    {
        _currentStatus = GameEvent.WIN;
        SceneManager.LoadScene(2);
        Debug.Log("Current game status: " + _currentStatus);
    }
    private void LossEvent()
    {
        _currentStatus = GameEvent.LOSS;
        SceneManager.LoadScene(2);
        Debug.Log("Current game status: " + _currentStatus);
    }

    private void QuitEvent()
    {
        _currentStatus = GameEvent.QUIT;
        Debug.Log("Quit successfully");
        Application.Quit();
    }

    #endregion

}

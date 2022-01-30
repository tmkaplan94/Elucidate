/*
 * Version - 1.0
 * Date - 01/10/2022
 * Description - GameManager controls the flow of the game.
 * Summary
 *  - GameManager extends Singleton, which extends MonoBehavior.
 *  - Currently, it manages the scene transitions from TitleScene to LevelOne.
 *  - Session duration is captured to test that Singleton design is working,
 *    ie. the GameManager persists across scene transitions
 * 
 * Author - Tyler Kaplan
 * Contributors
 *  - 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private static GameEvent _currentStatus;

    public static GameEvent CurrentStatus()
    {
        return _currentStatus;
    }

    private void OnEnable()
    {
        GameEventBus.Subscribe(GameEvent.TITLE, TitleEvent);
        GameEventBus.Subscribe(GameEvent.COUNTDOWN, CountdownEvent);
        GameEventBus.Subscribe(GameEvent.START, StartEvent);
        GameEventBus.Subscribe(GameEvent.PAUSE, PauseEvent);
        GameEventBus.Subscribe(GameEvent.RESUME, ResumeEvent);
        GameEventBus.Subscribe(GameEvent.FINISH, FinishEvent);
        GameEventBus.Subscribe(GameEvent.QUIT, QuitEvent);
    }

    private void Start()
    {
        _currentStatus = GameEvent.TITLE;
        Debug.Log("Current game status: " + _currentStatus);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameEvent.TITLE, TitleEvent);
        GameEventBus.Unsubscribe(GameEvent.COUNTDOWN, CountdownEvent);
        GameEventBus.Unsubscribe(GameEvent.START, StartEvent);
        GameEventBus.Unsubscribe(GameEvent.PAUSE, PauseEvent);
        GameEventBus.Unsubscribe(GameEvent.RESUME, ResumeEvent);
        GameEventBus.Unsubscribe(GameEvent.FINISH, FinishEvent);
        GameEventBus.Unsubscribe(GameEvent.QUIT, QuitEvent);
    }

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
    
    private void FinishEvent()
    {
        _currentStatus = GameEvent.FINISH;
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

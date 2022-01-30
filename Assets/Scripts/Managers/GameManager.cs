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
    public GameEvent CurrentStatus;

    private void OnEnable()
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    #region Event Functions

    private void TitleEvent()
    {
        
    }
    
    private void CountdownEvent()
    {
        
    }
    
    private void StartEvent()
    {
        
    }
    
    private void PauseEvent()
    {
        
    }
    
    private void ResumeEvent()
    {
        
    }
    
    private void FinishEvent()
    {
        
    }
    
    private void QuitEvent()
    {
        
    }

    #endregion
    
}

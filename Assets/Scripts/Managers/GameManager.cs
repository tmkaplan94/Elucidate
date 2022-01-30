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
    private GameObject _titleMenu;
    private GameObject _mainMenu;
    private GameObject _optionsMenu;
    
    private void Start()
    {
        GetMenuObjects();
        SetDefaultMenus();
    }

    #region TitleScene Functions

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit successfully");
        Application.Quit();
    }

    private void GetMenuObjects()
    {
        _titleMenu = GameObject.Find("Title Menu");
        _mainMenu = GameObject.Find("Main Menu");
        _optionsMenu = GameObject.Find("Options Menu");
    }
    
    private void SetDefaultMenus()
    {
        _titleMenu.SetActive(true);
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(false);
    }

    public void ActivateMainMenu()
    {
        _titleMenu.SetActive(false);
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
    }

    public void ActivateOptionsMenu()
    {
        _titleMenu.SetActive(false);
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }
    
    #endregion
}

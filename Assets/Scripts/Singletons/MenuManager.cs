/*
 * Author: Tyler Kaplan
 * Contributors: Grant Reed, Loc Trinh
 * Description: AudioManager configures and plays all sound at specified audio source.
 */
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : Singleton<MenuManager>
{
    // canvas items needed to control different menus
    [SerializeField] private GameObject _BGVidOutput;
    [SerializeField] private GameObject _BGImage;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private GameObject _titleMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _lossMenu;

    // subscribe to game events to display certain menus
    private void OnEnable()
    {
        GameEventBus.Title += SetDefaultMenus;
        GameEventBus.Start += DeactivateTitleMenus;
        GameEventBus.Pause += ActivatePauseMenu;
        GameEventBus.Resume += DeactivatePauseMenus;
        GameEventBus.Win += ActivateWinMenu;
        GameEventBus.Loss += ActivateLossMenu;
    }

    private void Start()
    {
        SetDefaultMenus();
    }

    // unsubscribe from game events that display certain menus
    private void OnDisable()
    {
        GameEventBus.Title -= SetDefaultMenus;
        GameEventBus.Start -= DeactivateTitleMenus;
        GameEventBus.Pause -= ActivatePauseMenu;
        GameEventBus.Resume -= DeactivatePauseMenus;
        GameEventBus.Win -= ActivateWinMenu;
        GameEventBus.Loss -= ActivateLossMenu;
    }

    // sets title scene menu on, and turns all others off
    private void SetDefaultMenus()
    {
        _titleMenu.SetActive(true);
        _mainMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _winMenu.SetActive(false);
        _lossMenu.SetActive(false);
        _BGImage.SetActive(true);
        _BGVidOutput.SetActive(true);
        
        float r = _backgroundImage.color.r;
        float g = _backgroundImage.color.g;
        float b = _backgroundImage.color.b;
        _backgroundImage.color = new Color(r, g, b, 255);
    }
    
    
    // toggles the proper menus on and off
    #region Public Menu Functions

    public void ActivateMainMenu()
    {
        _titleMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void DeactivateTitleMenus()
    {
        _titleMenu.SetActive(false);
        _mainMenu.SetActive(false);
        _BGImage.SetActive(false);
        _BGVidOutput.SetActive(false);
        
        float r = _backgroundImage.color.r;
        float g = _backgroundImage.color.g;
        float b = _backgroundImage.color.b;
        _backgroundImage.color = new Color(r, g, b, 0);
    }

    public void ActivatePauseMenu()
    {
        // display pause menu
        _pauseMenu.SetActive(true);
    }

    public void DeactivatePauseMenus()
    {
        _pauseMenu.SetActive(false);
    }
    public void ResumeButtonClicked()
    {
        GameEventBus.Resume?.Invoke();
    }

    public void ActivateWinMenu()
    {
        _winMenu.SetActive(true);
        DeactivatePauseMenus();
    }

    public void ActivateLossMenu()
    {
        _lossMenu.SetActive(true);
        DeactivatePauseMenus();
    }

    #endregion
    
    // functions needed for OnClick events
    #region Public GameEvent Functions

    public void PlayGame()
    {
        GameEventBus.Start?.Invoke();
    }

    public void GoToTitle()
    {
        GameEventBus.Title?.Invoke();
    }

    public void QuitGame()
    {
        GameEventBus.Quit?.Invoke();
    }

    #endregion

}

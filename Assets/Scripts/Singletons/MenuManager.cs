/*
 * Author: Tyler Kaplan
 * Contributors:
 * Description: AudioManager configures and plays all sound at specified audio source.
 */
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : Singleton<MenuManager>
{
    // canvas items needed to control different menus
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private GameObject _titleMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _mainOptionsMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseOptionsMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _lossMenu;

    // subscribe to game events to display certain menus
    private void OnEnable()
    {
        GameEventBus.Subscribe(GameEvent.TITLE, SetDefaultMenus);
        GameEventBus.Subscribe(GameEvent.START, DeactivateTitleMenus);
        GameEventBus.Subscribe(GameEvent.PAUSE, ActivatePauseMenu);
        GameEventBus.Subscribe(GameEvent.RESUME, DeactivatePauseMenus);
        GameEventBus.Subscribe(GameEvent.WIN, ActivateWinMenu);
        GameEvents.Subscribe(GameEvent.LOSS, ActivateLossMenu);
    }

    private void Start()
    {
        SetDefaultMenus();
    }

    // unsubscribe from game events that display certain menus
    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameEvent.START, DeactivateTitleMenus);
        GameEventBus.Unsubscribe(GameEvent.PAUSE, ActivatePauseMenu);
        GameEventBus.Unsubscribe(GameEvent.RESUME, DeactivatePauseMenus);
        GameEventBus.Unsubscribe(GameEvent.WIN, ActivateWinMenu);
        GameEvents.Unsubscribe(GameEvent.LOSS, ActivateLossMenu);
        GameEventBus.Unsubscribe(GameEvent.TITLE, SetDefaultMenus);
    }

    // sets title scene menu on, and turns all others off
    private void SetDefaultMenus()
    {
        _titleMenu.SetActive(true);
        _mainMenu.SetActive(false);
        _mainOptionsMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _pauseOptionsMenu.SetActive(false);
        _winMenu.SetActive(false);
        _lossMenu.SetActive(false);
        
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
        _mainOptionsMenu.SetActive(false);
    }
    
    public void ActivateMainOptionsMenu()
    {
        _titleMenu.SetActive(false);
        _mainMenu.SetActive(false);
        _mainOptionsMenu.SetActive(true);
    }

    public void DeactivateTitleMenus()
    {
        _titleMenu.SetActive(false);
        _mainMenu.SetActive(false);
        _mainOptionsMenu.SetActive(false);
        
        float r = _backgroundImage.color.r;
        float g = _backgroundImage.color.g;
        float b = _backgroundImage.color.b;
        _backgroundImage.color = new Color(r, g, b, 0);
    }

    public void ActivatePauseMenu()
    {
        _pauseMenu.SetActive(true);
        _pauseOptionsMenu.SetActive(false);
    }

    public void ActivatePauseOptionsMenu()
    {
        _pauseMenu.SetActive(false);
        _pauseOptionsMenu.SetActive(true);
    }

    public void DeactivatePauseMenus()
    {
        _pauseMenu.SetActive(false);
        _pauseOptionsMenu.SetActive(false);
    }

    public void ActivateWinMenu()
    {
        _winMenu.SetActive(true);
    }

    public void ActivateLossMenu()
    {
        _lossMenu.SetActive(true);
    }

    #endregion
    
    // functions needed for OnClick events
    #region Public GameEvent Functions

    public void PlayGame()
    {
        GameEventBus.Publish(GameEvent.START);
    }

    public void GoToTitle()
    {
        GameEventBus.Publish(GameEvent.TITLE);
    }

    public void QuitGame()
    {
        GameEventBus.Publish(GameEvent.QUIT);
    }

    #endregion

}

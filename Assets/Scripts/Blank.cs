using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Blank
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
}
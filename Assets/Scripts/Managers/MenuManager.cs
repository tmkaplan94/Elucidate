using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] private GameObject _titleMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _mainOptionsMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseOptionsMenu;
}

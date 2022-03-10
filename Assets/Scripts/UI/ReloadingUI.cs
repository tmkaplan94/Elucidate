using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingUI : MonoBehaviour
{
    [SerializeField] private GameObject _reloadUI;
    private void OnEnable()
    {
        GameEventBus.Reloading += currentlyReloading;
        GameEventBus.Reloaded += finishedReloading;
    }
    
    private void OnDisable()
    {
        GameEventBus.Reloading -= currentlyReloading;
        GameEventBus.Reloaded -= finishedReloading;
    }

    private void currentlyReloading()
    {
        _reloadUI.SetActive(true);
        
    }

    private void finishedReloading()
    {
        _reloadUI.SetActive(false);
        
    }
}

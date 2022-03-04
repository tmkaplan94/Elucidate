/*
 * Author: Tyler Kaplan
 * Contributors:
 * Description: Toggles mute on audio source.
 */

using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClickSounds : MonoBehaviour
{
    [SerializeField] private GameObject clickSounds;
    private bool _enabled;

    public void Awake()
    {
        _enabled = true;
    }

    public void ToggleMute()
    {
        if (enabled)
        {
            clickSounds.SetActive(false);
            _enabled = false;
        }
        else
        {
            clickSounds.SetActive(true);
            _enabled = true;
        }
    }
    
}

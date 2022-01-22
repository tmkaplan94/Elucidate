using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    private AudioManager _audioManager;
    private AudioSource _audioSource;
    private KeyCode _keyCode;

    public void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _audioSource = GetComponent<AudioSource>();
        SetMyKeyCode();
    }

    void Update()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            _audioManager.Play(_audioSource, gameObject.name);
        }
    }

    private void SetMyKeyCode()
    {
        string n = gameObject.name;

        switch (n)
        {
            case "1":
                _keyCode = KeyCode.Alpha1;
                break;
            case "2":
                _keyCode = KeyCode.Alpha2;
                break;
            case "3":
                _keyCode = KeyCode.Alpha3;
                break;
            case "4":
                _keyCode = KeyCode.Alpha4;
                break;
            case "5":
                _keyCode = KeyCode.Alpha5;
                break;
            case "6":
                _keyCode = KeyCode.Alpha6;
                break;
            case "7":
                _keyCode = KeyCode.Alpha7;
                break;
            case "8":
                _keyCode = KeyCode.Alpha8;
                break;
            default:
                _keyCode = KeyCode.Alpha0;
                break;
        }
    }
}

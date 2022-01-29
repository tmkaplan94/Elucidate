/*
 * Version - 1.0
 * Date - 01/29/2022
 * Description - Plays named audio on Start.
 * Summary
 * 
 * Author - Tyler Kaplan
 * Contributors - 
 */

using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioSource : MonoBehaviour
{
    [SerializeField] private string _name;
    private AudioSource _audioSource;
    private GameObject _audioManager;
    
    void Start()
    {
        // cache needed fields
        _audioManager = GameObject.Find("AudioManager");
        if (_audioManager == null)
        {
            _audioManager = GameObject.Find("Audio Manager");
        }
        _audioSource = GetComponent<AudioSource>();
        
        // ensure there is an AudioManager in scene
        if (_audioManager == null)
        {
            Debug.LogError("No AudioManager exists in Scene");
            return;
        }
        
        
        // AudioSource needs to rely on AudioManager to play audio
        _audioManager.GetComponent<AudioManager>().Play(_audioSource, _name);
    }
}

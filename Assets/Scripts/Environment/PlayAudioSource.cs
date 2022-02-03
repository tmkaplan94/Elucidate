/*
 * Author: Tyler Kaplan
 * Contributors: 
 * Description: Sends named audio with source to AudioManager to configure and play.
 */
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
    }

    // AudioSource needs to rely on AudioManager configurations
    public void Play()
    {
        _audioManager.GetComponent<AudioManager>().ConfigureAudio(_audioSource, _name);
    }
}

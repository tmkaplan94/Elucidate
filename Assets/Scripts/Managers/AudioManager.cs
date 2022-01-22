/*
 * Version - 1.0
 * Date - 01/22/2022
 * Description - AudioManager managers all audio sources.
 * Summary
 *  - AudioManager extends Singleton, which extends MonoBehavior.
 *  - contains a varying list of all sound sources
 *  - responsible for finding and playing them
 * 
 * Author - Tyler Kaplan
 * Contributors
 *  - 
 */

using System;
using UnityEngine;
using UnityEditor.Audio;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;
    
    // Play the background theme.
    public void Start()
    {
        Play(GameObject.Find("Main Camera").GetComponent<AudioSource>(), "Background");
    }
    

    // Play the given AudioSource with parameters based on AudioManager.
    public void Play(AudioSource source, string name)
    {
        // Find Sound in AudioManager based on name parameter
        Sound s = Array.Find(sounds, sound => sound.name == name);
    
        // Print a warning and return if no Sound is found
        if (s == null)
        {
            Debug.LogWarning("Cannot find " + name + " Sound in AudioManager!");
            return;
        }
        
        // Set source parameters based on AudioManager Sound.
        source.clip = s.clip;
        source.outputAudioMixerGroup = s.group;
        source.volume = s.volume;
        source.pitch = s.pitch;
        source.spatialBlend = s.spatial;
        source.mute = s.mute;
        source.playOnAwake = s.awake;
        source.loop = s.loop;

        // Play AudioSource
        source.Play();
    }

}

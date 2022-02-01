/*
 * Version - 1.1
 * Date - 01/27/2022
 * Description - AudioManager manages/plays all audio sources.
 * Summary
 *  - AudioManager extends Singleton, which extends MonoBehavior.
 *  - contains a varying list of all sounds
 *  - all objects rely on AudioManager to play audio
 * 
 * Author - Tyler Kaplan
 * Contributors - 
 */
using System;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;

    // Configure and play the given AudioSource with parameters based on AudioManager.
    public void ConfigureAudio(AudioSource source, string name)
    {
        // Find Sound in AudioManager based on name parameter
        Sound s = Array.Find(sounds, sound => sound.name == name);
    
        // Print a warning and return if no Sound is found
        if (s == null)
        {
            Debug.LogError("No \"" + name + "\" Sound exists in AudioManager");
            return;
        }
        
        // Set source parameters based on AudioManager Sound.
        source.clip = s.clip;
        source.outputAudioMixerGroup = s.group;
        source.volume = s.volume;
        source.pitch = s.pitch;
        if (s.spatial)
        {
            source.spatialBlend = 1;
        }
        else
        {
            source.spatialBlend = 0;
        }
        source.mute = s.mute;
        source.playOnAwake = s.awake;
        source.loop = s.loop;

        // Play AudioSource
        source.Play();
    }

}

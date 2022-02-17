/*
 * Author: Tyler Kaplan
 * Contributors: Loc Trinh
 * Description: AudioManager configures and plays all sound at specified audio source.
 */
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

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
        source.clip = s.clip[Random.Range(0, s.clip.Length)];
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

    public void MuteAll()
    {
        foreach(Sound entry in sounds)
        {
            if(!entry.mute )
            {
                entry.mute = true;
            }
            else if(entry.mute)
            {
                entry.mute = false;
            }        
        }
    }

    /*
    public void ControlVolume(Sound s)
    {
        s.volume = 
    }
    */

}

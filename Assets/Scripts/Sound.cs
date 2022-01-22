/*
 * Version - 1.0
 * Date - 01/22/2022
 * Description - Sound is a custom class used by the AudioManager.
 * Summary
 *  - Sound has parameters for easy edit in AudioManager.
 * 
 * Author - Tyler Kaplan
 * Contributors
 *  - 
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup group;
    [Range(0, 1)] public float volume;
    [Range(0.1f, 3)] public float pitch;
    [Range(0, 1)] public float spatial;
    public bool mute;
    public bool awake;
    public bool loop;
}

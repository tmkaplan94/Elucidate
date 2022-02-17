/*
 * Author: Tyler Kaplan
 * Contributors: Loc Trinh
 * Description: Sound is a custom class used by the AudioManager.
 *
 * Sound has parameters for easy edit in AudioManager.
 */
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip[] clip;
    public AudioMixerGroup group;
    [Range(0, 1)] public float volume;
    [Range(0.1f, 3)] public float pitch;
    public bool spatial;
    public bool mute;
    public bool awake;
    public bool loop;
}

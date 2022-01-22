/*
 * Version - 1.0
 * Date - 01/22/2022
 * Description - Sound is a custom class used by the AudioManager.
 * Summary
 *  - Sound extends ScriptableObject.
 * 
 * Author - Tyler Kaplan
 * Contributors
 *  - 
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Sound : ScriptableObject
{
    public string _name;
    public AudioClip _clip;
    [Range(0, 1)] public float _volume;
    [Range(0, 1)] public float _pitch;
}

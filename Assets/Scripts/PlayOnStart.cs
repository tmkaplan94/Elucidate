/*
 * Author: Grant Reed
 * Contributors: Loc Trinh, Tyler Kaplan
 * Description: Gets the attached PlayAudioSource() and calls play on start.
 */
using UnityEngine;

[RequireComponent(typeof (PlayAudioSource))]
public class PlayOnStart : MonoBehaviour
{
    private PlayAudioSource _sound;
    
    private void Start()
    {
        _sound = GetComponent<PlayAudioSource>();
        _sound.Play();
    }

}

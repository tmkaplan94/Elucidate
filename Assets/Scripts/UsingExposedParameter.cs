using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UsingExposedParameter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string exposedParameter;

    public void Set()
    {
        mixer.SetFloat(exposedParameter, _slider.value);
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSpecialList PlayerList;

    private void OnEnable()
    {
        PlayerList.Add(this);
    }

    private void OnDisable()
    {
        PlayerList.Remove(this);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerRuntimeSet PlayerList;

    private void OnEnable()
    {
        PlayerList.Add(this);
    }

    private void OnDisable()
    {
        PlayerList.Remove(this);
    }
}

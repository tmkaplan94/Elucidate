using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public RobotRuntimeSet RobotList;

    private void OnEnable()
    {
        RobotList.Add(this);
    }

    private void OnDisable()
    {
        RobotList.Remove(this);
    }
}

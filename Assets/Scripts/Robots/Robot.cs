using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private RobotSpecialList RobotList;
    private int count = 0;
    private void OnEnable()
    {
        RobotList.Add(this);
        count++;
        Debug.Log(count);
    }

    private void OnDisable()
    {
        RobotList.Remove(this);
    }
}

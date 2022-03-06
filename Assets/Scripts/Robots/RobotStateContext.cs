using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateContext
{
    public IRobotState CurrentState { get; set; }

    public void Transition(IRobotState state)
    {
        CurrentState = state;
        CurrentState.Handle();
    }
}

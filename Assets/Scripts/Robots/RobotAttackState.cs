using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttackState : MonoBehaviour, IRobotState
{
    // the unique controller for this robot
    private RobotController _robotController;
    
    public void Handle(RobotController robotController)
    {
        // set the controller for this robot if not already set
        if (!_robotController)
        {
            _robotController = robotController;
        }
    }
}

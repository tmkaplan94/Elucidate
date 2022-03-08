using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotApproachState : MonoBehaviour, IRobotState
{
    // the unique controller for this robot
    private RobotController _robotController;
    
    // "handle" the state behavior
    public void Handle(RobotController robotController)
    {
        // set the controller for this robot if not already set
        if (!_robotController)
        {
            _robotController = robotController;
        }
        
        Approach();
    }

    // sets destination to target position using NavMeshAgent
    private void Approach()
    {
        _robotController.FaceTarget();
        _robotController.Transform.position += _robotController.Transform.forward * _robotController.robotStats.MovementSpeed;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFleeState : MonoBehaviour, IRobotState
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
        
        Flee();
    }
    
    // sets destination to target position using NavMeshAgent
    private void Flee()
    {
        _robotController.FaceAway();
        Vector3 translation = _robotController.MyTransform.forward * _robotController.Stats.MovementSpeed;
        _robotController.MyTransform.position += translation;
    }
}

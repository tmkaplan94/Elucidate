/*
 * Author: Tyler Kaplan
 * Contributors: Brian Caballero
 * Description: Flee state for robots.
 *
 * Flees away from target for a period of time.
 * Flees by facing away from target, then moving forward.
 */
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
    
    // flees away from target for a period of time
    private void Flee()
    {
        _robotController.FaceAway();
        Vector3 translation = _robotController.MyTransform.forward * _robotController.Stats.MovementSpeed;
        _robotController.MyTransform.position += translation;
    }
}

/*
 * Author: Tyler Kaplan
 * Contributors: Brian Caballero
 * Description: Approach state for robots.
 *
 * Approaches targeted players based on approach radius in robot stats.
 * Approaches by facing target, then moving forward.
 */
using UnityEngine;
using UnityEngine.AI;

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
        _robotController.NavMeshAgent.SetDestination(_robotController.TargetTransform.position);
    }

}

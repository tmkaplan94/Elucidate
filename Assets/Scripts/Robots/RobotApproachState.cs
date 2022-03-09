using System;
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
        Vector3 translation = _robotController.MyTransform.forward * _robotController.Stats.MovementSpeed;
        _robotController.MyTransform.position += translation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_robotController.Type == RobotType.Collider)
        {
            float damage = _robotController.Stats.CollisionDamage;
            other.gameObject.GetComponent<IDamageable<float>>().TakeDamage(damage);
            _robotController.CurrentState = _robotController._fleeState;
            _robotController._isFleeing = true;
        }
    }
}

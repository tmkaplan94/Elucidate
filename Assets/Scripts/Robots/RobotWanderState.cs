using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWanderState : MonoBehaviour, IRobotState
{
    // the unique controller for this robot
    private RobotController _robotController;
    
    // bools to determine how to wander
    private bool _isWalking;
    private bool _isRotatingLeft;
    private bool _isRotatingRight;
    
    // "handle" the state behavior
    public void Handle(RobotController robotController)
    {
        // set the controller for this robot if not already set
        if (!_robotController)
        {
            _robotController = robotController;
        }
        
        // initiate wandering
        StartCoroutine(Wander());
    }
    
    // gets random values to use for move()
    private IEnumerator Wander()
    {
        // get random values to wander
        int rotationTime = Random.Range(1, 3);
        int rotationWait = Random.Range(1, 3);
        int rotationDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);
        
        // determine if robot is moving
        if (_robotController.robotStats.IsConstantlyWalking)
        {
            yield return new WaitForSeconds(0);
            yield return new WaitForSeconds(walkTime);
        }
        else
        {
            yield return new WaitForSeconds(walkWait);
            _isWalking = true;
            yield return new WaitForSeconds(walkTime);
            _isWalking = false;
        }
    
        // determine if robot is rotating
        yield return new WaitForSeconds(rotationWait);
        if (rotationDirection == 1)
        {
            _isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            _isRotatingRight = false;
        }
        if (rotationDirection == 2)
        {
            _isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            _isRotatingLeft = false;
        }
        
        // initiate movement
        Move();
    }

    // perform movement using values captures in wander()
    private void Move()
    {
        if (_isRotatingRight)
        {
            _robotController.Transform.Rotate(transform.up * Time.deltaTime * _robotController.robotStats.RotationSpeed);
        }
        if (_isRotatingLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -_robotController.robotStats.RotationSpeed);
        }
        if (_isWalking)
        {
            _robotController.Transform.position += transform.forward * _robotController.robotStats.MovementSpeed;
        }
    }

}

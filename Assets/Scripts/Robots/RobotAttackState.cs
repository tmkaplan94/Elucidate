using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        
        Attack();
    }

    // choose attack style based on robot type
    private void Attack()
    {
        switch (_robotController.robotType)
        {
            case RobotType.Maniac:
                Chase();
                Fire();
                break;
            case RobotType.CircleStrafer:
                CircleStrafe();
                Fire();
                break;
            case RobotType.SideStrafer:
                // do something
                Fire();
                break;
        }
    }
    
    // instantiate bullet prefab with a direction, force, and damage amount
    private void Fire()
    {
        if (_robotController.CanFire)
        {
            // get new position and rotation for new bullet
            Vector3 newPosition = _robotController.FirePoint.position;
            Quaternion newRotation = _robotController.FirePoint.rotation;
            
            // instantiate new bullet
            GameObject newBullet = Instantiate(_robotController.robotStats.BulletPrefab, newPosition, newRotation);
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * _robotController.robotStats.BulletSpeed);
            newBullet.GetComponent<Bullet>().Damage = _robotController.robotStats.BulletDamage;
            Destroy(newBullet, 2.0f);
            
            // play audio
            _robotController.Audio.Play();
            
            // reset shooting timer and bool
            _robotController.ResetShootingTimer();
            _robotController.CanFire = false;
        }
    }
    
    // continue to chase and shoot target
    private void Chase()
    {
        _robotController.NavMeshAgent.SetDestination(_robotController.Target.position);
        _robotController.FaceTarget();
    }
    
    // strafe around target while attacking
    private void CircleStrafe()
    {
        Vector3 rotatePosition = _robotController.Target.position;
        float degreesPerSecond = _robotController.robotStats.RotationSpeed * Time.deltaTime;
        
        // chooses either 0 or 1 to decide direction to rotate in
        int direction = Random.Range(0,2);
        if (direction == 0)
        {
            degreesPerSecond *= -1;
        }

        _robotController.Transform.RotateAround(rotatePosition, Vector3.up, degreesPerSecond);
        _robotController.FaceTarget();
    }
    
}

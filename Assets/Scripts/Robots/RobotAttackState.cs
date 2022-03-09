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
        switch (_robotController.Type)
        {
            case RobotType.Chaser:
                Chase();
                Fire();
                break;
            case RobotType.Tactical:
                Chase();
                Fire();
                break;
            case RobotType.Strafer:
                Strafe();
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
            GameObject newBullet = Instantiate(_robotController.Stats.BulletPrefab, newPosition, newRotation);
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * _robotController.Stats.BulletSpeed);
            newBullet.GetComponent<Bullet>().Damage = _robotController.Stats.BulletDamage;
            Destroy(newBullet, 2.0f);
            
            // play audio
            _robotController.Audio.Play();
            
            // reset shooting timer and bool
            _robotController.ResetShootingTimer();
            _robotController.CanFire = false;
        }
    }
    
    // continue to chase target
    private void Chase()
    {
        _robotController.NavMeshAgent.SetDestination(_robotController.TargetTransform.position);
        _robotController.FaceTarget();
    }

    // strafe around target while attacking
    private void Strafe()
    {
        // get rotation values from robot stats in editor
        Vector3 rotatePosition = _robotController.TargetTransform.position;
        int minRotationDegrees = _robotController.Stats.strafingSpeed.minValue;
        int maxRotationDegrees = _robotController.Stats.strafingSpeed.maxValue;
        int degreesPerSecond = Random.Range(minRotationDegrees, maxRotationDegrees);

        // // chooses either 0 or 1 to decide direction to rotate in
        // int direction = Random.Range(0,2);
        // if (direction == 0)
        // {
        //     degreesPerSecond *= -1;
        // }

        // perform rotation while looking at target (strafe)
        _robotController.MyTransform.RotateAround(rotatePosition, Vector3.up, degreesPerSecond * Time.deltaTime);
        _robotController.FaceTarget();
    }

}

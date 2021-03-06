/*
 * Author: Tyler Kaplan
 * Contributors: Brian Caballero
 * Description: Attack state for robots.
 *
 * Attacks in 3 different ways, based on robot type.
 * Chaser constantly chases and fires weapon.
 * Tactical chases robot while firing for a period of time, then flees for a period of time. (currently abstracted)
 * Strafer strafes in circles around target while in range and fires weapon.
 */

using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Photon.Pun;

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
            
            // reset shooting timer
            _robotController.ResetShootingTimer();
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
        float degreesPerSecond = (_robotController.StrafingSpeed * _robotController.StrafingDirection * Time.deltaTime);
            
        _robotController.MyTransform.RotateAround(rotatePosition, Vector3.up, degreesPerSecond);
        _robotController.FaceTarget();
    }

}

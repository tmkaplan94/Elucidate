/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Deals with all enemy behaviors.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AIShooting))]
public class AIMovementScript : MonoBehaviour
{
    // editor exposed fields
    [SerializeField] private PlayerList players;
    [SerializeField] private AIStats stats;
    
    // private fields
    private Rigidbody _rigidbody;
    private AIShooting _shooting;
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private bool _isWandering;
    private bool _isRotatingLeft;
    private bool _isRotatingRight;
    private bool _isWalking;
    private float targetDistance;
    private float currentDistance;

    private void Start()
    {
        targetDistance = Mathf.Infinity;
        currentDistance = Mathf.Infinity;
        
        // cache needed components
        _rigidbody = GetComponent<Rigidbody>();
        _shooting = GetComponent<AIShooting>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        // initialize booleans
        _isWandering = false;
        _isRotatingLeft = false;
        _isRotatingRight = false;
        _isWalking = false;
        
        // Set the walking mode, depending on the AIState.
        switch (stats.CurrentState)
        {
            case AIState.Wandering:
                {
                    stats.IsConstantlyWalking = true;
                    _isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIState.Patrolling:
                {
                    stats.IsConstantlyWalking = false;
                    _isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIState.Sprinting:
                {
                    stats.IsConstantlyWalking = true;
                    _isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIState.RunNGun:
                {
                    stats.IsConstantlyWalking = true;
                    _isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIState.Camping:
                {
                    stats.IsConstantlyWalking = false;
                    _navMeshAgent.stoppingDistance = stats.DetectRadius - 5;
                    break;
                }
        }

    }
    
    // Check if any player is in range
    private void Update()
    {
        List<Transform> targetTransforms = players.GetAllTransforms();
        
        foreach (Transform t in targetTransforms)
        {
            currentDistance = Vector3.Distance(t.position, transform.position);
            if (currentDistance < targetDistance)
            {
                targetDistance = currentDistance;
                _target = t;
            }
        }
    }

    // Check if player is in range to shoot, otherwise wander
    private void FixedUpdate()
    {
        float distance = Mathf.Infinity;
        if (_target != null)
        {
            distance = Vector3.Distance(_target.position, transform.position);
        }
        
        if (stats.CurrentState == AIState.RunNGun)
        {
            int randomShooting = Random.Range(1, 10);
            if (randomShooting > 5)
            {
                _shooting.Fire();
            }
        }
        
        if (distance <= stats.DetectRadius)
        {
            ActionChasing(distance);
        }
        else
        {
            ActionWandering();
        }
    }
    
    // Chasing player that is in range shoot once close enough
    private void ActionChasing(float distance)
    {
        _navMeshAgent.SetDestination(_target.position);
        if (distance <= _navMeshAgent.stoppingDistance)
        {
            FaceTarget();
            _shooting.Fire();
        }
    }
    
    // mindlessly wander, time and degrees of turns are random
    private void ActionWandering()
    {
        if (_isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (_isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * stats.RotationSpeed);
        }
        if (_isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -stats.RotationSpeed);
        }
        if (_isWalking == true)
        {
            _rigidbody.transform.position += transform.forward * stats.MovementSpeed;
        }
    }
    
    // Works with function above.
    private IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotationWait =  Random.Range(1, 3);
        int rotationDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);


        _isWandering = true;
        if (stats.IsConstantlyWalking == true)
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
        _isWandering = false;
    }
    
    // Face target to aim properly
    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    // Used only to see/test range of AI
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.DetectRadius);
    }
}
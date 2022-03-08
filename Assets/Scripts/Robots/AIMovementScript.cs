/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Deals with all enemy behaviors.
 */

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
    [SerializeField] private RobotStats stats;
    [SerializeField] private RobotState defaultState;
    [SerializeField] private RobotState currentState;
    
    // private fields
    private Rigidbody _rigidbody;
    private AIShooting _shooting;
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private bool _isWandering;
    private bool _isRotatingLeft;
    private bool _isRotatingRight;
    private bool _isWalking;
    private float _targetDistance;
    private float _currentDistance;
    
    private void Start()
    {
        _targetDistance = Mathf.Infinity;
        _currentDistance = Mathf.Infinity;

        // cache needed components
        _rigidbody = GetComponent<Rigidbody>();
        _shooting = GetComponent<AIShooting>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    
        // initialize booleans
        _isWandering = false;
        _isRotatingLeft = false;
        _isRotatingRight = false;
        _isWalking = false;
        
    }
    
    // Get the closest player in the scene's distance from current postion.
    private void Update()
    {

    }
    
    // Change state of ai if player is in range.
    private void FixedUpdate()
    {
        PerformActions();
    }
    //Do actions based on ai state
    private void PerformActions()
    {

    }
    
    // Chasing player that is in range shoot once close enough
    private void ActionChasing()
    {
        _navMeshAgent.SetDestination(_target.position);
        if (_targetDistance <= _navMeshAgent.stoppingDistance)
        {
            //FaceTarget();
            _shooting.Fire();
        }
    }

}
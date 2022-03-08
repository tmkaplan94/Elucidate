using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayAudioSource))]
public class RobotController : MonoBehaviour
{
    [SerializeField] private PlayerList players;
    [SerializeField] private RobotType robotType;
    public RobotStats robotStats;

    public IRobotState CurrentState { get; set; }
    
    private NavMeshAgent _navMeshAgent;
    private Transform _transform;
    private List<Transform> _targetTransforms;
    private Transform _currentTarget;
    private float _targetDistance;
    private float _currentDistance;
    private Transform _firePoint;
    private PlayAudioSource _audio;
    private bool _isShooting;
    private float _shootingTimer;
    private bool _isFleeing;
    private int _fleeTimer;

    #region Properties

    public Transform Transform => _transform;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public Transform Target => _currentTarget;

    #endregion

    private void Awake()
    {
        AddStatesAsComponents();
    }

    private void Start()
    {
        // initialize needed variables
        _currentDistance = Mathf.Infinity;
        _fleeTimer = robotStats.FleeCooldown;
        _shootingTimer = robotStats.ShootingCooldown;
        _firePoint = transform.GetChild(3).GetChild(0).transform;
        _audio = gameObject.GetComponent<PlayAudioSource>();

        // cache needed components
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();

        // set the default state
        CurrentState = GetComponent<RobotWanderState>();
    }

    private void Update()
    {
        LocateTarget();
        CheckRadius();
        CheckIfShooting();
        CheckIfFleeing();
    }

    private void FixedUpdate()
    {
        CurrentState.Handle(this);
    }

    // adds the states specified in the editor as components
    private void AddStatesAsComponents()
    {
        // add IRobotStates based on robotType
        switch (robotType)
        {
            case RobotType.Maniac:
                gameObject.AddComponent<RobotWanderState>();
                gameObject.AddComponent<RobotApproachState>();
                gameObject.AddComponent<RobotFleeState>();
                break;
        }
    }

    // locate the nearest target by calculating the distance to the nearest player Transform
    private void LocateTarget()
    {
        _targetTransforms = players.GetAllTransforms();
        _targetDistance = Mathf.Infinity;
        foreach (Transform t in _targetTransforms)
        {
            _currentDistance = Vector3.Distance(t.position, transform.position);
            if (_currentDistance < _targetDistance)
            {
                _targetDistance = _currentDistance;
                _currentTarget = t;
            }
        }
    }
    
    // check if target is in approach and attack radius
    private void CheckRadius()
    {
        if (_isFleeing) { return; }
        
        if (_currentDistance <= robotStats.ApproachRadius)
        {
            if (_currentDistance <= robotStats.AttackRadius)
            {
                CurrentState = GetComponent<RobotFleeState>();
                _isFleeing = true;
                return;
            }
            
            CurrentState = GetComponent<RobotApproachState>();
        }
        else
        {
            CurrentState = GetComponent<RobotWanderState>();
        }
    }
    
    // if shot, decrement timer; if timer hits zero, can shoot again
    private void CheckIfShooting()
    {
        if (_isShooting)
        {
            _shootingTimer--;
            if (_shootingTimer <= 0)
            {
                Shoot();
            }
        }
    }

    // if fleeing, decrement timer; if timer hits zero, go back to wandering state
    private void CheckIfFleeing()
    {
        if (_isFleeing)
        {
            _fleeTimer--;
            if (_fleeTimer <= 0)
            {
                CurrentState = GetComponent<RobotWanderState>();
                _fleeTimer = robotStats.FleeCooldown;
                _isFleeing = false;
            }
        }
    }

    // face the current target
    public void FaceTarget()
    {
        if (_currentTarget)
        {
            Vector3 direction = (_currentTarget.position - _transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        else
        {
            Debug.LogWarning("There is no current target yet FaceTarget() has been called.");
        }
    }
    
    // face away from the current target
    public void FaceAway()
    {
        if (_currentTarget)
        {
            Vector3 direction = (_currentTarget.position - _transform.position).normalized;
            direction *= -1;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        else
        {
            Debug.LogWarning("There is no current target yet FaceAway() has been called.");
        }
    }

    // instantiate bullet prefab with a direction, force, and damage amount
    public void Shoot()
    {
        
    }
    
    // used to see/test radius of robots
    private void OnDrawGizmosSelected()
    {
        float radius = robotStats.AttackRadius;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}

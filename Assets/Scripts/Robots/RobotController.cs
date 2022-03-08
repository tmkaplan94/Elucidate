using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayAudioSource))]
public class RobotController : MonoBehaviour
{
    // public/serialized fields
    [SerializeField] private PlayerList players;
    public RobotType robotType;
    public RobotStats robotStats;
    
    // robot states
    private IRobotState _wanderState;
    private IRobotState _approachState;
    private IRobotState _attackState;
    private IRobotState _fleeState;

    // properties
    public IRobotState CurrentState { get; set; }
    public bool CanFire { get; set; }
    public bool CanZigZag { get; set; }
    public Transform FirePoint { get; private set; }
    public PlayAudioSource Audio { get; private set; }

    // private components/variables
    private NavMeshAgent _navMeshAgent;
    private Transform _transform;
    private List<Transform> _targetTransforms;
    private Transform _currentTarget;
    private float _targetDistance;
    private float _currentDistance;
    private bool _isShooting;
    private int _shootingTimer;
    private bool _isFleeing;
    private int _fleeTimer;
    private int _zigZagTimer;

    #region Properties

    public Transform Transform => _transform;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public Transform Target => _currentTarget;
    public float TargetDistance => _currentDistance;

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
        _shootingTimer = 0;
        _zigZagTimer = 0;
        FirePoint = transform.GetChild(2).GetChild(0).transform;
        Audio = gameObject.GetComponent<PlayAudioSource>();

        // cache other needed components
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();

        // set the default state
        CurrentState = _wanderState;
    }

    private void Update()
    {
        LocateTarget();
        CheckRadius();
        CheckIfShooting();
        CheckIfFleeing();
        CheckIfZigZagTime();
    }

    private void FixedUpdate()
    {
        CurrentState.Handle(this);
    }

    // adds the states specified in the editor as components
    private void AddStatesAsComponents()
    {
        // add IRobotStates common to all robot types
        _wanderState = gameObject.AddComponent<RobotWanderState>();
        _approachState = gameObject.AddComponent<RobotApproachState>();
        
        // add additional IRobotStates based on robot type
        switch (robotType)
        {
            case RobotType.Chaser:
                _attackState = gameObject.AddComponent<RobotAttackState>();
                break;
            case RobotType.Tactical:
                _attackState = gameObject.AddComponent<RobotFleeState>();
                _fleeState = gameObject.AddComponent<RobotAttackState>();
                break;
            case RobotType.Strafer:
                _attackState = gameObject.AddComponent<RobotFleeState>();
                break;
            case RobotType.Chicken:
                _fleeState = gameObject.AddComponent<RobotAttackState>();
                break;
            case RobotType.Collider:
                _fleeState = gameObject.AddComponent<RobotAttackState>();
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
                CurrentState = _attackState;
                _isShooting = true;
                return;
            }
            
            CurrentState = _approachState;
        }
        else
        {
            CurrentState = _wanderState;
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
                CanFire = true;
            }
        }
    }

    // public function to reset shooting timer back to the set cooldown
    public void ResetShootingTimer()
    {
        _shootingTimer = robotStats.ShootingCooldown;
    }
    
    //if zig-zagging, decrement timer; if timer hits zero, change direction
    private void CheckIfZigZagTime()
    {
        _zigZagTimer--;
        if (_zigZagTimer <= 0)
        {
            CanZigZag = true;
        }
    }
    
    // public function to reset zigzag timer back to the set cooldown
    public void ResetZigZagTimer()
    {
        _zigZagTimer = robotStats.ZigZagCooldown;
    }

    // if fleeing, decrement timer; if timer hits zero, go back to wandering state
    private void CheckIfFleeing()
    {
        if (_isFleeing)
        {
            _fleeTimer--;
            if (_fleeTimer <= 0)
            {
                CurrentState = _wanderState;
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

    // used to see/test radius of robots
    private void OnDrawGizmosSelected()
    {
        float radius = robotStats.AttackRadius;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}

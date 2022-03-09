using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayAudioSource))]
public class RobotController : MonoBehaviour
{
    // serialized fields
    [SerializeField] private PlayerList players;
    [SerializeField] private RobotType type;
    [SerializeField] private RobotStats stats;
    
    // private fields
    //private IRobotState _currentState;
    private IRobotState _wanderState;
    private IRobotState _approachState;
    private IRobotState _attackState;
    private IRobotState _fleeState;
    
    private List<Transform> _targetTransforms;
    private bool _isShooting;
    private int _shootingTimer;
    private int _attackTimer;
    private bool _isFleeing;
    private int _fleeingTimer;
    private bool _isStrafing;
    private int _strafingTimer;
    
    // properties
    #region Properties
    
    public RobotType Type => type;
    public RobotStats Stats => stats;
    
    public IRobotState CurrentState { get; private set; }
    public Transform MyTransform { get; private set; }
    public Transform TargetTransform { get; private set; }
    public float CurrentDistance { get; private set; }
    public float TargetDistance { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public PlayAudioSource Audio { get; private set; }
    public Transform FirePoint { get; private set; }
    
    public bool CanFire { get; set; }
    public bool StrafeDirection { get; set; }
    
    #endregion
    
    private void Awake()
    {
        AddStatesAsComponents();
    }

    private void Start()
    {
        // initialize needed variables
        CurrentDistance = Mathf.Infinity;
        _shootingTimer = 0;
        _fleeingTimer = Stats.FleeingCooldown;
        _attackTimer = Stats.AttackCooldown;

        // cache needed components
        MyTransform = GetComponent<Transform>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Audio = gameObject.GetComponent<PlayAudioSource>();
        FirePoint = transform.GetChild(3).GetChild(0).transform;

        // set the default state
        CurrentState = _wanderState;
    }

    private void Update()
    {
        LocateTarget();
        CheckRadius();
        CheckIfShooting();
        CheckIfFleeing();
        CheckIfStrafing();
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
        switch (type)
        {
            case RobotType.Chaser:
                _attackState = gameObject.AddComponent<RobotAttackState>();
                break;
            case RobotType.Tactical:
                _attackState = gameObject.AddComponent<RobotAttackState>();
                _fleeState = gameObject.AddComponent<RobotFleeState>();
                break;
            case RobotType.Strafer:
                _attackState = gameObject.AddComponent<RobotAttackState>();
                break;
            case RobotType.Chicken:
                _fleeState = gameObject.AddComponent<RobotFleeState>();
                break;
            case RobotType.Collider:
                _fleeState = gameObject.AddComponent<RobotFleeState>();
                break;
        }
    }

    // locate the nearest target by calculating the distance to the nearest player Transform
    private void LocateTarget()
    {
        _targetTransforms = players.GetAllTransforms();
        TargetDistance = Mathf.Infinity;
        foreach (Transform t in _targetTransforms)
        {
            CurrentDistance = Vector3.Distance(t.position, transform.position);
            if (CurrentDistance < TargetDistance)
            {
                TargetDistance = CurrentDistance;
                TargetTransform = t;
            }
        }
    }
    
    // check if target is in approach and attack radius
    private void CheckRadius()
    {
        if (_isFleeing) { return; }
        
        if (CurrentDistance <= stats.ApproachRadius)
        {
            if (CurrentDistance <= stats.AttackRadius)
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
            if (type == RobotType.Tactical)
            {
                _attackTimer--;
            }
            _shootingTimer--;
            
            if (_shootingTimer <= 0)
            {
                CanFire = true;
            }

            if (type == RobotType.Tactical && _attackTimer <= 0)
            {
                CurrentState = _fleeState;
                _isFleeing = true;
                _attackTimer = Stats.AttackCooldown;
            }
        }
    }

    // public function to reset shooting timer back to the set cooldown
    public void ResetShootingTimer()
    {
        _shootingTimer = stats.ShootingCooldown;
    }

    // if fleeing, decrement timer; if timer hits zero, go back to wandering state
    private void CheckIfFleeing()
    {
        if (_isFleeing)
        {
            _fleeingTimer--;
            if (_fleeingTimer <= 0)
            {
                CurrentState = _wanderState;
                _fleeingTimer = stats.FleeingCooldown;
                _isFleeing = false;
            }
        }
    }
    
    // public function to reset fleeing timer back to the set cooldown
    public void ResetFleeingTimer()
    {
        _fleeingTimer = Stats.FleeingCooldown;
    }
    
    //if strafing, decrement timer; if timer hits zero, change direction
    private void CheckIfStrafing()
    {
        _strafingTimer--;
        if (_strafingTimer <= 0)
        {
            StrafeDirection = true;
        }
    }
    
    // public function to reset strafing timer back to the set cooldown
    public void ResetStrafingTimer()
    {
        _strafingTimer = stats.StrafingCooldown;
    }

    // face the current target
    public void FaceTarget()
    {
        if (TargetTransform)
        {
            Vector3 direction = (TargetTransform.position - MyTransform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            MyTransform.rotation = Quaternion.Slerp(MyTransform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        else
        {
            Debug.LogWarning("There is no current target yet FaceTarget() has been called.");
        }
    }
    
    // face away from the current target
    public void FaceAway()
    {
        if (TargetTransform)
        {
            Vector3 direction = (TargetTransform.position - MyTransform.position).normalized;
            direction *= -1;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            MyTransform.rotation = Quaternion.Slerp(MyTransform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        else
        {
            Debug.LogWarning("There is no current target yet FaceAway() has been called.");
        }
    }

    // used to see/test radius of robots
    private void OnDrawGizmosSelected()
    {
        float radius = stats.AttackRadius;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}

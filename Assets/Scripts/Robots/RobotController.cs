/*
 * Author: Tyler Kaplan
 * Contributors: Brian Caballero, Grant Reed
 * Description: Acts as the brain/state context for each robot
 */
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
    
    // public fields
    public IRobotState _wanderState;
    public IRobotState _approachState;
    public IRobotState _attackState;
    public IRobotState _fleeState;
    
    // private fields
    //private IRobotState _currentState;
    private List<Transform> _targetTransforms;
    private bool _isAttacking;
    private int _shootingTimer;
    private int _tacticalTimer;
    private bool _isFleeing;
    private int _fleeingTimer;
    private bool _isStrafing;
    private int _strafingTimer;
    
    // properties
    #region Properties
    
    public RobotType Type => type;
    public RobotStats Stats => stats;
    
    public IRobotState CurrentState { get; set; }
    public Transform MyTransform { get; private set; }
    public Transform TargetTransform { get; private set; }
    public float CurrentDistance { get; private set; }
    public float TargetDistance { get; private set; }
    public NavMeshAgent NavMeshAgent { get; private set; }
    public PlayAudioSource Audio { get; private set; }
    public Transform FirePoint { get; private set; }
    public bool CanFire { get; private set; }
    public bool StrafeDirection { get; private set; }
    
    #endregion
    
    // adds and stores the necessary states (per robot) as components
    private void Awake()
    {
        AddStatesAsComponents();
    }

    private void Start()
    {
        // initialize needed variables
        CurrentDistance = Mathf.Infinity;
        _isFleeing = false;
        _isAttacking = false;
        _isStrafing = false;
        _shootingTimer = 0;
        CanFire = true;
        _fleeingTimer = Stats.FleeingCooldown;
        
        ResetTacticalTimer();


        // cache needed components
        MyTransform = GetComponent<Transform>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Audio = gameObject.GetComponent<PlayAudioSource>();
        FirePoint = transform.GetChild(3).GetChild(0).transform;

        // set the default state to wander
        CurrentState = _wanderState;
    }

    // constantly search for new targets, checking radius, and determining necessary behavior
    private void Update()
    {
        LocateTarget();
        CheckRadii();
        CheckIfAttacking();
        CheckIfFleeing();
        CheckIfStrafing();
    }

    // "handle" the current state's behavior
    private void FixedUpdate()
    {
        CurrentState.Handle(this);
    }

    // adds the needed states as components
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
    private void CheckRadii()
    {
        if (_isFleeing) { return; }
        
        if (CurrentDistance <= stats.ApproachRadius)
        {
            if (CurrentDistance <= stats.AttackRadius)
            {
                if (Type == RobotType.Chicken)
                {
                    CurrentState = _fleeState;
                    _isFleeing = true;
                    return;
                }
                
                CurrentState = _attackState;
                _isAttacking = true;
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
    private void CheckIfAttacking()
    {
        if (_isAttacking)
        {
            if (type == RobotType.Tactical)
            {
                _tacticalTimer--;
            }
            
            _shootingTimer++;
            if (_shootingTimer >= Stats.ShootingSpeed)
            {
                CanFire = true;
            }

            if (type == RobotType.Tactical && _tacticalTimer <= 0)
            {
                CurrentState = _fleeState;
                _isFleeing = true;
                ResetTacticalTimer();
            }
        }
    }

    // public function to reset shooting timer back to the set cooldown
    public void ResetShootingTimer()
    {
        _shootingTimer = 0;
        CanFire = false;
    }
    
    // calculate a new random value for the tactical timer
    private void ResetTacticalTimer()
    {
        int attackSpeedMin = Stats.tacticalTimer.minValue;
        int attackSpeedMax = Stats.tacticalTimer.maxValue;
        _tacticalTimer = Random.Range(attackSpeedMin, attackSpeedMax);
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
                _fleeingTimer = Stats.FleeingCooldown;
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
        _strafingTimer = Stats.StrafingCooldown;
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
        float radius = stats.ApproachRadius;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}

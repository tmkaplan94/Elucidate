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

    // private fields
    private IRobotState _wanderState;
    private IRobotState _approachState;
    private IRobotState _attackState;
    private IRobotState _fleeState;
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
    public int StrafingDirection { get; private set; }
    public int StrafingSpeed { get; set; }

    #endregion
    
    // adds and stores the necessary states (per robot) as components
    private void Awake()
    {
        AddStatesAsComponents();
    }

    private void Start()
    {
        // initialize and reset needed variables
        InitializeLocateTargetValues();
        InitializeShootingValues();
        InitializeFleeingValues();
        InitializeTacticalValues();
        InitializeStrafingValues();

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
    
    // initialize current distance to infinity
    private void InitializeLocateTargetValues()
    {
        CurrentDistance = Mathf.Infinity;
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

            if (type == RobotType.Strafer)
            {
                _isStrafing = true;
            }
            
            _shootingTimer++;
            if (_shootingTimer >= 500)
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
    
    // initialize shooting values
    private void InitializeShootingValues()
    {
        ResetShootingTimer();
        CanFire = true;
    }

    // calculate a new random value for the shooting timer and reset CanFire to false
    public void ResetShootingTimer()
    {
        int shootingSpeedMin = Stats.shootingSpeed.minValue;
        int shootingSpeedMax = Stats.shootingSpeed.maxValue;
        _shootingTimer = Random.Range(shootingSpeedMin, shootingSpeedMax);

        CanFire = false;
    }
    
    // initialize tactical timer
    private void InitializeTacticalValues()
    {
        ResetTacticalTimer();
    }
    
    // calculate a new random value for the tactical timer
    public void ResetTacticalTimer()
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
                ResetFleeingTimer();
                _isFleeing = false;
            }
        }
    }
    
    // initialize fleeing values
    private void InitializeFleeingValues()
    {
        int fleeingTimerMin = Stats.fleeingTimer.minValue;
        int fleeingTimerMax = Stats.fleeingTimer.maxValue;
        _fleeingTimer = Random.Range(fleeingTimerMin, fleeingTimerMax);
        
        _isFleeing = false;
    }
    
    // public function to reset fleeing timer back to the set cooldown
    public void ResetFleeingTimer()
    {
        int fleeingTimerMin = Stats.fleeingTimer.minValue;
        int fleeingTimerMax = Stats.fleeingTimer.maxValue;
        _fleeingTimer = Random.Range(fleeingTimerMin, fleeingTimerMax);
    }
    
    //if strafing, decrement timer; if timer hits zero, change direction
    private void CheckIfStrafing()
    {
        if (_isStrafing)
        {
            _strafingTimer--;
            if (_strafingTimer <= 0)
            {
                ChangeStrafingDirection();
                ChangeStrafingSpeed();
                ResetStrafingTimer();
            }
        }
    }
    
    // initialize a random per robot strafing speed and direction, and initialize strafing values
    private void InitializeStrafingValues()
    {
        // get a random strafing direction
        int randomValue = Random.Range(0, 2);
        if (randomValue == 1)
        {
            StrafingDirection = 1;
        }
        else if (randomValue == 0)
        {
            StrafingDirection = -1;
        }
        
        // get a random strafing speed within range
        int minRotationDegrees = Stats.strafingSpeed.minValue;
        int maxRotationDegrees = Stats.strafingSpeed.maxValue;
        StrafingSpeed = Random.Range(minRotationDegrees, maxRotationDegrees);
        
        // initialize strafing values
        _isStrafing = false;
        ResetStrafingTimer();
    }
    
    // change strafing direction
    private void ChangeStrafingDirection()
    {
        if (StrafingDirection == -1)
        {
            StrafingDirection = 1;
        }
        else if (StrafingDirection == 1)
        {
            StrafingDirection = -1;
        }
    }
    
    // change strafing speed
    private void ChangeStrafingSpeed()
    {
        int minRotationDegrees = Stats.strafingSpeed.minValue;
        int maxRotationDegrees = Stats.strafingSpeed.maxValue;
        StrafingSpeed = Random.Range(minRotationDegrees, maxRotationDegrees);
    }
    
    // public function to reset strafing timer back to the set cooldown
    public void ResetStrafingTimer()
    {
        _strafingTimer = Stats.StrafingTimer;
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

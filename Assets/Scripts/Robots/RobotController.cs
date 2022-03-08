using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class RobotController : MonoBehaviour
{
    [SerializeField] private PlayerList players;
    [SerializeField] private RobotType robotType;
    public RobotStats robotStats;
    //[SerializeField] private RobotState[] robotStates;
    
    public IRobotState CurrentState { get; set; }
    
    private NavMeshAgent _navMeshAgent;
    private Transform _transform;
    private List<Transform> _targetTransforms;
    private Transform _currentTarget;
    private float _targetDistance;
    private float _currentDistance;

    #region Properties

    public Transform Transform => _transform;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public Transform Target => _currentTarget;
    public float TargetDistance => _targetDistance;
    public float CurrentDistance => _currentDistance;

    #endregion

    private void Awake()
    {
        AddStatesAsComponents();
    }

    private void Start()
    {
        // initialize distance to infinity
        _currentDistance = Mathf.Infinity;
        
        // cache needed components
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();

        // set the default state
        CurrentState = GetComponent<RobotWanderState>();
    }

    private void Update()
    {
        LocateTarget();
        CheckApproachRadius();
    }

    private void FixedUpdate()
    {
        CurrentState.Handle(this);
    }

    public void Transition(IRobotState state)
    {
        CurrentState = state;
    }

    // adds the states specified in the editor as components
    private void AddStatesAsComponents()
    {
        // // OPTION A: add IRobotStates based on robotStates
        // foreach (RobotState s in robotStates)
        // {
        //     switch (s)
        //     {
        //         case RobotState.Wander:
        //             gameObject.AddComponent<RobotWanderState>();
        //             break;
        //         case RobotState.Approach:
        //             gameObject.AddComponent<RobotApproachState>();
        //             break;
        //     }
        // }
        
        // OPTION B: add IRobotStates based on robotType
        switch (robotType)
        {
            case RobotType.Maniac:
                gameObject.AddComponent<RobotWanderState>();
                gameObject.AddComponent<RobotApproachState>();
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
    
    // check if target is in detection radius
    public void CheckApproachRadius()
    {
        if (_currentDistance <= robotStats.ApproachRadius)
        {
            CurrentState = GetComponent<RobotApproachState>();
        }
        else
        {
            CurrentState = GetComponent<RobotWanderState>();
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

    // used to see/test range of robots
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, robotStats.ApproachRadius);
    }
    
}

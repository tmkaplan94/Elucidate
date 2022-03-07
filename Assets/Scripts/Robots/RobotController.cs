using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    [SerializeField] private PlayerList players;
    [SerializeField] private RobotType robotType;
    public RobotStats robotStats;
    [SerializeField] private RobotState[] robotStates;
    
    public IRobotState CurrentState { get; set; }
    
    private NavMeshAgent _navMeshAgent;
    private Transform _transform;
    private List<Transform> _targetTransforms;
    private Transform _currentTarget;
    private float _targetDistance;
    private float _currentDistance;

    #region Properties

    public Transform Transform => _transform;

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

        // set the default state and execute
        CurrentState = GetComponent<RobotWanderState>();
        CurrentState.Handle(this);
    }

    private void Update()
    {
        LocateTarget();
    }
    
    public void Transition(IRobotState state)
    {
        CurrentState = state;
        CurrentState.Handle(this);
    }

    // adds the states specified in the editor as components
    private void AddStatesAsComponents()
    {
        // OPTION A: add IRobotStates based on robotStates
        foreach (RobotState s in robotStates)
        {
            switch (s)
            {
                case RobotState.Wandering:
                    gameObject.AddComponent<RobotWanderState>();
                    break;
                // case RobotState.etc:
                //      gameObject.AddComponent<etc>();
                //      break;
            }
        }
        
        // // OPTION B: add IRobotStates based on robotType
        // switch (robotType)
        // {
        //     case RobotType.A:
        //         gameObject.AddComponent<RobotWanderState>();
        //         // etc
        //         // etc
        //         break;
        // }
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
    
    // face the current target
    private void FaceTarget()
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

}

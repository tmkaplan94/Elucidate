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
    [SerializeField] private AIState defaultState;
    [SerializeField] private AIState currentState;
    private void Start()
    {
        targetDistance = Mathf.Infinity;
        currentDistance = Mathf.Infinity;
        defaultState = stats.CurrentState;

        // cache needed components
        _rigidbody = GetComponent<Rigidbody>();
        _shooting = GetComponent<AIShooting>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        // initialize booleans
        _isWandering = false;
        _isRotatingLeft = false;
        _isRotatingRight = false;
        _isWalking = false;

        // Set the default walking mode, depending on the default AIState.
        _isWalking = stats.IsConstantlyWalking;
    }

    // Get the closest player in the scene's distance from current postion.
    private void Update()
    {
        List<Transform> targetTransforms = players.GetAllTransforms();
        targetDistance = Mathf.Infinity;
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

    // Change state of ai if player is in range.
    private void FixedUpdate()
    {
        if (targetDistance <= stats.DetectRadius)
        {
            currentState = AIState.Chasing;
        }
        else
        {
            currentState = defaultState;
        }
        PerformActions();
    }
    //Do actions based on ai state
    private void PerformActions()
    {
        switch (currentState)
        {
            case AIState.RunNGun:
                {
                    int randomShooting = Random.Range(1, 10);
                    if (randomShooting > 5)
                    {
                        _shooting.Fire();
                    }
                    ActionWandering();
                    break;
                }
            case AIState.Chasing:
                {
                    ActionChasing();
                    break;
                }
            default:
                {
                    ActionWandering();
                    break;
                }
        }
    }

    // Chasing player that is in range shoot once close enough
    private void ActionChasing()
    {
        _navMeshAgent.SetDestination(_target.position);
        if (targetDistance <= _navMeshAgent.stoppingDistance)
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
        int rotationWait = Random.Range(1, 3);
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
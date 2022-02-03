/*
 * Author: Brian Caballero
 * Contributors:
 * Description: Deals with all enemy behaviors.
 */
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AIShooting))]
public class AIMovementScript : MonoBehaviour
{
    // editor exposed fields
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

    private void Start()
    {
        // cache needed components
        _rigidbody = GetComponent<Rigidbody>();
        _shooting = GetComponent<AIShooting>();
        _target = GameObject.Find("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        // initialize booleans
        _isWandering = false;
        _isRotatingLeft = false;
        _isRotatingRight = false;
        _isWalking = false;
        
        // Set the walking mode, depending on the AIState.
        switch (stats.currentState)
        {
            case AIState.Wandering:
                {
                    stats.isConstantlyWalking = true;
                    _isWalking = stats.isConstantlyWalking;
                    break;
                }

            case AIState.Patrolling:
                {
                    stats.isConstantlyWalking = false;
                    _isWalking = stats.isConstantlyWalking;
                    break;
                }

            case AIState.Sprinting:
                {
                    stats.isConstantlyWalking = true;
                    _isWalking = stats.isConstantlyWalking;
                    break;
                }

            case AIState.RunNGun:
                {
                    stats.isConstantlyWalking = true;
                    _isWalking = stats.isConstantlyWalking;
                    break;
                }

            case AIState.Camping:
                {
                    stats.isConstantlyWalking = false;
                    _navMeshAgent.stoppingDistance = stats.detectRadius - 5;
                    break;
                }
        }

    }
    
    // Check if player is in range to shoot, otherwise wander
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        if (stats.currentState == AIState.RunNGun)
        {
            int randomShooting = Random.Range(1, 10);
            if (randomShooting > 5)
            {
                _shooting.Fire();
            }
        }
        if (distance <= stats.detectRadius)
        {
            ActionChasing(distance);
        }
        else
        {
            ActionWandering();
        }
    }
    
    // Chasing player that is in range shoot once close enough
    void ActionChasing(float distance)
    {
        _navMeshAgent.SetDestination(_target.position);
        if (distance <= _navMeshAgent.stoppingDistance)
        {
            FaceTarget();
            _shooting.Fire();
        }
    }
    
    // mindlessly wander, time and degrees of turns are random
    void ActionWandering()
    {
        if (_isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (_isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * stats.rotationSpeed);
        }
        if (_isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -stats.rotationSpeed);
        }
        if (_isWalking == true)
        {
            _rigidbody.transform.position += transform.forward * stats.movementSpeed;
        }
    }
    
    // Works with function above.
    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotationWait =  Random.Range(1, 3);
        int rotationDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);


        _isWandering = true;
        if (stats.isConstantlyWalking == true)
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
    void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    // Used only to see/test range of AI
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.detectRadius);
    }
}
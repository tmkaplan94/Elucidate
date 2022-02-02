using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementScript : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private AIShooting Shooting;
    [SerializeField]
    private AIStats stats;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    Rigidbody rb;
    NavMeshAgent agent;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        switch (stats.CurrentState)//Set the walking mode, depending on the AI_State
        {
            case AIStats.AI_State.Wandering:
                {
                    stats.IsConstantlyWalking = true;
                    isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIStats.AI_State.Patroling:
                {
                    stats.IsConstantlyWalking = false;
                    isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIStats.AI_State.Sprinting:
                {
                    stats.IsConstantlyWalking = true;
                    isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIStats.AI_State.RunNGuning:
                {
                    stats.IsConstantlyWalking = true;
                    isWalking = stats.IsConstantlyWalking;
                    break;
                }

            case AIStats.AI_State.Camping:
                {
                    stats.IsConstantlyWalking = false;
                    agent.stoppingDistance = stats.DetectRadius - 5;
                    break;
                }
        }

    }
    private void FixedUpdate()//Check if player is nearby
                              //if in range, shoot, otherwise wander
    {
        float distance = Vector3.Distance(Target.position, transform.position);
        if (stats.CurrentState == AIStats.AI_State.RunNGuning)
        {
            int RandomShooting = Random.Range(1, 10);
            if (RandomShooting > 5)
            {
                Shooting.Fire();
            }
        }
        if (distance <= stats.DetectRadius)
        {
            ActionChasing(distance);
        }
        else
        {
            ActionWandering();
        }
    }
    void ActionChasing(float distance)//Chasing player that is in range
                                      //shoot once close enough
    {
        agent.SetDestination(Target.position);
        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            Shooting.Fire();
        }
    }
    void ActionWandering()//Mindlessly wander, time and degrees of turns are random
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * stats.RotationSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -stats.RotationSpeed);
        }
        if (isWalking == true)
        {
            rb.transform.position += transform.forward * stats.MovementSpeed;
        }
    }
    IEnumerator Wander()//Works with function above
    {
        int RotationTime = Random.Range(1, 3);
        int RoationWait =  Random.Range(1, 3);
        int RoationDirection = Random.Range(1, 3);
        int WalkWait = Random.Range(1, 3);
        int WalkTime = Random.Range(1, 3);


        isWandering = true;
        if (stats.IsConstantlyWalking == true)
        {
            yield return new WaitForSeconds(0);
            yield return new WaitForSeconds(WalkTime);
        }
        else
        {
            yield return new WaitForSeconds(WalkWait);
            isWalking = true;
            yield return new WaitForSeconds(WalkTime);
            isWalking = false;
        }

        yield return new WaitForSeconds(RoationWait);
        if (RoationDirection == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(RotationTime);
            isRotatingRight = false;
        }
        if (RoationDirection == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(RotationTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
    void FaceTarget()//Face target to aim properly
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void OnDrawGizmosSelected()//Used only to see/test range of AI
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.DetectRadius);
    }
}
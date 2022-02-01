using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementScript : MonoBehaviour
{
    /*
    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed = 100f;
    [SerializeField]
    private bool IsConstantlyWalking;
    [SerializeField]
    private AI_State CurrentState;

    [SerializeField]
    private float DetectRadius = 10f;
    
    */
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private AIShooting Shooting;
    [SerializeField]
    private AIStats stats;

    /*
    public Transform firepoint;
    public GameObject Bullet;
    public float BulletSpeed = 1000f;
    public int ShootingSpeed = 35;
    private int ShootingCount = 0;
    */

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
        switch (stats.CurrentState)
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
                    //stats.DetectRadius *= 2;
                    //isWalking = true;
                    break;
                }

            case AIStats.AI_State.Sprinting:
                {
                    stats.IsConstantlyWalking = true;
                    isWalking = stats.IsConstantlyWalking;
                    //stats.MovementSpeed *= 2.5f;
                    //stats.DetectRadius /= 2;
                    break;
                }

            case AIStats.AI_State.RunNGuning:
                {
                    stats.IsConstantlyWalking = true;
                    isWalking = stats.IsConstantlyWalking;
                    //stats.MovementSpeed *= 2;
                    break;
                }

            case AIStats.AI_State.Camping:
                {
                    stats.IsConstantlyWalking = false;
                    //stats.ShootingSpeed /= 0.25f;
                    //stats.MovementSpeed /= 0.66f;
                    //stats.DetectRadius *= 5;
                    agent.stoppingDistance = stats.DetectRadius - 5;
                    break;
                }
        }

    }
    private void FixedUpdate()
    {/*
        float distance = Vector3.Distance(stats.Target.position, transform.position);
        
        switch (stats.CurrentState)
        {
            case AIStats.AI_State.Wandering:
                {
                    stats.IsConstantlyWalking = true;
                    isWalking = stats.IsConstantlyWalking;
                    if (distance <= stats.DetectRadius)
                    {
                        ActionChasing(distance);
                    }
                    else
                    {
                        ActionWandering();
                    }
                    break;
                }
            
            case AIStats.AI_State.Patroling:
                {
                    stats.IsConstantlyWalking = false;
                    isWalking = stats.IsConstantlyWalking;
                    stats.DetectRadius *= 2;
                    //isWalking = true;
                    if (distance <= stats.DetectRadius)
                    {
                        ActionChasing(distance);
                    }
                    else
                    {
                        ActionWandering();
                    }
                    stats.DetectRadius /= 2;
                    break;
                }

            case AIStats.AI_State.Sprinting:
                {
                    stats.IsConstantlyWalking = true;
                    isWalking = stats.IsConstantlyWalking;
                    stats.MovementSpeed *= 2.5f;
                    stats.DetectRadius /= 2;
                    if (distance <= stats.DetectRadius)
                    {
                        ActionChasing(distance);
                    }
                    else
                    {
                        ActionWandering();
                    }
                    stats.MovementSpeed /= 2.5f;
                    stats.DetectRadius *= 2;
                    break;
                }

            case AIStats.AI_State.RunNGuning:
                {
                    stats.IsConstantlyWalking = true; 
                    isWalking = stats.IsConstantlyWalking;
                    stats.MovementSpeed *= 2;
                    int RandomShooting = Random.Range(1, 10);
                    if (RandomShooting > 5)
                    {
                        Shooting.Fire();
                    }
                    if (distance <= stats.DetectRadius)
                    {
                        ActionChasing(distance);
                    }
                    else
                    {
                        ActionWandering();
                    }
                    stats.MovementSpeed /= 2;
                    break;
                }

            case stats.AI_State.Camping:
                {
                    stats.IsConstantlyWalking = false;
                    break;
                }
        }
        */
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
    void ActionChasing(float distance)
    {
        agent.SetDestination(Target.position);
        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            Shooting.Fire();
        }
    }
    void ActionWandering()
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
    IEnumerator Wander()
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
    void FaceTarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    /*
    void Shoot()
    {
        GameObject newBullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * BulletSpeed);
        Destroy(newBullet, 2.0f);
    }
    */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.DetectRadius);
    }

    /*public enum AI_State
    {
        Wandering,
        Patroling,
        Sprinting,
        RunNGuning,
        Camping
    }
    */
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementScript : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed = 100f;
    public bool IsConstantlyWalking = true;

    public float DetectRadius = 10f;
    public Transform Target;

    public Transform firepoint;
    public GameObject Bullet;
    public float BulletSpeed = 1000f;
    public int ShootingSpeed = 40;
    private int ShootingCount = 0;


    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Rigidbody rb;
    NavMeshAgent agent;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(IsConstantlyWalking == true)
        {
            isWalking = true;
        }
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        float distance = Vector3.Distance(Target.position, transform.position);
        if (distance <= DetectRadius)
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
            if (ShootingCount >= ShootingSpeed)
            {
                Shoot();
                ShootingCount = 0;
            }
            ShootingCount += 1;
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
            transform.Rotate(transform.up * Time.deltaTime * RotationSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -RotationSpeed);
        }
        if (isWalking == true)
        {
            rb.transform.position += transform.forward * MovementSpeed;
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
        if (IsConstantlyWalking == true)
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
    void Shoot()
    {
        GameObject newBullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * BulletSpeed);
        Destroy(newBullet, 2.0f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectRadius);
    }
    
}
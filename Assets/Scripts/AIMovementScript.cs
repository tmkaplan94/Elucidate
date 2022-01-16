using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementScript : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed = 100f;
    public bool IsConstantlyWalking = true;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(IsConstantlyWalking == true)
        {
            isWalking = true;
        }
    }
    private void Update()
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
}
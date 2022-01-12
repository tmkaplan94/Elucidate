using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed;

    private float moveX, moveZ;
    private Vector3 lookDir;
    private Rigidbody rb;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GetComponent<PlayerStats>();
        moveSpeed = stats.GetMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        lookDir = GetLookAtTarget();
    }

    private void FixedUpdate()
    {
        Move();
        Aim();
    }

    Vector3 GetLookAtTarget()
    {
        Vector3 target;
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayLength;
        groundPlane.Raycast(cameraRay, out rayLength);
        
        target = cameraRay.GetPoint(rayLength);
        target.y = transform.position.y;

        return target;
    }

    private void Move()
    {
        Vector3 movement;
        movement.x = moveX;
        movement.z = moveZ;
        movement.y = 0f;
        if (movement.magnitude > 0f)
        {
            movement.Normalize();
            movement *= moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }

    private void Aim()
    {
        transform.LookAt(lookDir);
    }
}

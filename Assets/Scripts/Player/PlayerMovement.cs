using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
/**
 * version: 1.0
 * Date: 1/12/2022
 * Description: This class takes input from the player and adjusts the players game object accordingly.
 * Summary: The player can move on the xz plane and rotates along the y axis toward the mouse 
 *          position. Currently, a ray is sent from the camera to the xz plane to determine the 
 *          mouse position in world space.
 * Notes: The rigidbody movePosition function is used for movement and the 
 *          Transform lookat function is used for player aim
 *          Im not sure yet what side effects those functions might have.
 * 
 * 
 * Author: Grant Reed
 * Contributors:
 * 
 */
public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed;

    private float moveX, moveZ;
    private Vector3 lookDir;
    private Rigidbody rb;
    private PlayerStats stats;

    private PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GetComponent<PlayerStats>();
        moveSpeed = stats.MoveSpeed;
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            //Getting input from player every frame.
            moveX = Input.GetAxisRaw("Horizontal");
            moveZ = Input.GetAxisRaw("Vertical");
            lookDir = GetLookAtTarget();
        }
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            //actually moving player here.
            Move();
            Aim();
        }
    }

    /*
     *Casts a ray from the camera to the ground plane at the position of the mouse in screen space
     *to determine where the player should be looking. 
     */
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
    /*
     * Moves the player's rigidbody based on input.*/
    private void Move()
    {
        Vector3 movement;
        movement.x = moveX;
        movement.z = moveZ;
        movement.y = 0f;
        //This ensures that the player always moves at the same speed (moveSpeed).
        if (movement.magnitude > 0f)
        {
            movement.Normalize();
            movement *= moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }
    //Points the player transform in the direction of lookDir.
    private void Aim()
    {
        transform.LookAt(lookDir);
    }
}

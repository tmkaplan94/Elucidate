/*
 * Author: Grant Reed
 * Contributors:
 * Description: This class takes input from the player and adjusts the player game object accordingly.
 * 
 * The player can move on the xz plane and rotates along the y axis toward the mouse position.
 * Currently, a ray is sent from the camera to the xz plane to determine the mouse position in world space.
 * The rigidbody movePosition function is used for movement and the Transform look-at function is used for player aim.
 */
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    // private fields
    [SerializeField] private Camera _camera;
    private Vector3 _lookTarget;
    private PlayerStats _stats;
    private Rigidbody _rigidbody;
    private Vector3 _position;
    private float _moveSpeed;
    private float _moveX;
    private float _moveZ;
    private PhotonView _view;

    private void Start()
    {
        _stats = GetComponent<PlayerStats>();
        _rigidbody = GetComponent<Rigidbody>();
        _position = transform.position;
        _view = GetComponent<PhotonView>();
        
        // get move speed based on PlayerStats.cs
        _moveSpeed = _stats.MoveSpeed;
    }

    private void Update()
    {
        if (_view.IsMine)
        {
        // get input from player every frame
        _moveX = Input.GetAxisRaw("Horizontal");
        _moveZ = Input.GetAxisRaw("Vertical");
        _lookTarget = GetLookAtTarget();   
        }
    }

    private void FixedUpdate()
    {
        if (_view.IsMine)
        {     
            // apply move and aim independent of framerate
            Move();
            Aim();
        }
    }


    // Cast a ray from camera to the ground at the position of the mouse in screen space.
    private Vector3 GetLookAtTarget()
    {
        Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        
        groundPlane.Raycast(cameraRay, out float rayLength);

        Vector3 target = cameraRay.GetPoint(rayLength);
        target.y = _position.y;

        return target;
    }
    
    // Moves the player's rigidbody based on input.
    private void Move()
    {
        Vector3 movement;
        movement.x = _moveX;
        movement.z = _moveZ;
        movement.y = 0f;
        // This ensures that the player always moves at the same _moveSpeed).
        if (movement.magnitude > 0f)
        {
            movement.Normalize();
            movement *= _moveSpeed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + movement);
        }
    }
    // Points the player transform in the direction of _lookDirection.
    private void Aim()
    {
        Vector3 lookVec = _lookTarget - transform.position;
        lookVec.y = 0f;
        Quaternion lookRot = Quaternion.LookRotation(lookVec);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, _stats.RotationSpeed * Time.fixedDeltaTime);
    }
}

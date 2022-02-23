/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: This class defines the movement behavior of a player based on player stats. 
 *              The actual movement functions (Move, Aim) are public and called by playerinputhandler.
 * 
 * 
 * The player can move on the xz plane and rotates along the y axis toward the mouse position.
 * Currently, a ray is sent from the camera to the xz plane to determine the mouse position in world space.
 * The rigidbody movePosition function is used for movement and the Transform look-at function is used for player aim.
 */
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    // private fields
    [SerializeField] private Camera _camera;
    private PlayerStats _stats;
    private Rigidbody _rigidbody;
    private Vector3 _position;
    private float _moveSpeed;

    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void Start()
    {
        _stats = GetComponent<PlayerStats>();
        _rigidbody = GetComponent<Rigidbody>();
        _position = transform.position;
        
        // get move speed based on PlayerStats.cs
        _moveSpeed = _stats.MoveSpeed;
    }

    // Moves the player's rigidbody based on input.
    public void Move(Vector3 movementInput)
    {
        movementInput.y = 0f;
        // This ensures that the player always moves at the same _moveSpeed).
        if (movementInput.magnitude > 0f)
        {
            movementInput.Normalize();
            movementInput *= _moveSpeed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + movementInput);
        }
        
        // Animating
        float Z = Vector3.Dot(movementInput.normalized, transform.forward);
        float X = Vector3.Dot(movementInput.normalized, transform.right);

        _animator.SetFloat("Z", Z, 0.1f, Time.deltaTime);
        _animator.SetFloat("X", X, 0.1f, Time.deltaTime); 
    }

    // Cast a ray from camera to the ground at the position of the mouse in screen space.
    public Vector3 GetLookAtTarget(Vector2 mousePos)
    {
        Ray cameraRay = _camera.ScreenPointToRay(mousePos);
        Plane groundPlane = new Plane(Vector3.up, transform.position);

        groundPlane.Raycast(cameraRay, out float rayLength);

        Vector3 target = cameraRay.GetPoint(rayLength);
        target.y = _position.y;

        return target;
    }
    // Points the player transform in the direction of _lookDirection.
    public void Rotate(Vector3 target)
    {
        Vector3 lookVec = target - transform.position;
        lookVec.y = 0f;
        Quaternion lookRot = Quaternion.LookRotation(lookVec);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, _stats.RotationSpeed * Time.fixedDeltaTime);
    }
}

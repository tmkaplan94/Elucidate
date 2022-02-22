/*
 * Author: Grant Reed
 * Contributors:
 * Description: This class defines the movement behavior of a player based on player stats. 
 *              The actualy movement functions (Move, Aim) are public and called by playerinputhandler.
 * 
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

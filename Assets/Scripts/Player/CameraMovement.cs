/*
 * Author: Grant Reed
 * Contributors:
 * Description: Controls the movement of the main camera in a scene.
 * 
 * Currently a player transform must be added in the inspector.
 * This will eventually be changed when multiplayer is added.
 */
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // editor exposed fields
    [SerializeField] private Transform playerTransform;
    
    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}

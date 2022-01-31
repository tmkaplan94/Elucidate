using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * version: 1.0
 * Date: 1/12/2022
 * Description: Controls the movement of the main camera in a scene.
 * Notes:
 * Currently a player transform must be added in the inspector.
 * This will eventually be changed when multiplayer is added.
 * 
 * Author: Grant Reed
 * Contributers:
 * 
 */
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    private Transform targetLocation;

    void Update()
    {
        //Updates the camera rig position every frame based on player position.
        //currently there's no damping or any fun stuff happening.
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}

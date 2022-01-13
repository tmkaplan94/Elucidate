using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * 
 * 
 * Author: Grant Reed
 * Date: 1/12/2022
 */
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    Transform targetLocation;

    void Update()
    {
        //Updates the camera rig position every frame based on player position.
        //currently there's no damping or any fun stuff happening.
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}

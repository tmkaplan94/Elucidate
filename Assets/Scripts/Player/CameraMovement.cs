/*
 * Author: Grant Reed
 * Contributors: Tyler Kaplan
 * Description: Controls the movement of the player's attached camera.
 */
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _offX;
    [SerializeField] private float _height;
    [SerializeField] private float _offZ;
    [SerializeField] private Camera _cam;

    // values to cache and use
    private Vector3 offsetVec;
    private Transform myTransform;

    private void Start()
    {      
        offsetVec = new Vector3(_offX, _height, _offZ);
        myTransform = gameObject.transform;
    }

    private void LateUpdate()
    {
        _cam.transform.position = myTransform.position + offsetVec;
        _cam.transform.LookAt(myTransform);
    }
    
}

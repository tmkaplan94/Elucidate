/*
 * Author: Grant Reed
 * Contributors:
 * Description: Controls the movement of the player's attached camera.
 */
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _offX;
    [SerializeField] private float _height;
    [SerializeField] private float _offZ;
    [SerializeField] private Camera _cam;

    private Vector3 offsetVec;


    private void Start()
    {      
        offsetVec = new Vector3(_offX, _height, _offZ);
    }

    private void LateUpdate()
    {
        _cam.transform.position = this.gameObject.transform.position + offsetVec;
        _cam.transform.LookAt(this.gameObject.transform);
    }



}

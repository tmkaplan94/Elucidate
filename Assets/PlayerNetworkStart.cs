using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetworkStart : MonoBehaviour
{
    [SerializeField] GameObject _cameraRig;
    [SerializeField] PhotonView _view;
    [SerializeField] PlayerInputHandler _inputHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_view.IsMine)
        {
            _inputHandler.enabled = false;
            Destroy(_cameraRig);
        }
    }

}

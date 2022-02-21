using UnityEngine;
using Photon.Pun;

/*
 * Author: Grant Reed
 * Contributors: 
 * Description: Turns off conflicting components of players that are not the local player.
 */
public class PlayerNetworkStart : MonoBehaviour
{
    [SerializeField] GameObject _cameraRig;
    [SerializeField] PhotonView _view;
    [SerializeField] PlayerInputHandler _inputHandler;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject flashlight;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_view.IsMine)
        {
            Destroy(playerUI);
            flashlight.SetActive(false);
            _inputHandler.enabled = false;
            Destroy(_cameraRig);
        }
    }

}

/*
 * Author: Grant Reed
 * Contributors:
 * Description: This class allows players to join a room in the network. It does not really manage or 
 *              maintain any rooms yet, since there is no reason to yet.
 */
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomManagement : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField _createInput;
    [SerializeField]
    private InputField _joinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(_createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        GameEventBus.Start?.Invoke();
    }
}
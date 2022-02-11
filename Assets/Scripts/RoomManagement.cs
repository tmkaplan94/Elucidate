/*
 * Author:
 * Contributors:
 * Description:
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
        PhotonNetwork.LoadLevel(3);
    }
}
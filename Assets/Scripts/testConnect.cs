
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testConnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        print("connecting to server.");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        print("connected.");

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected for " + cause.ToString());
    }

}
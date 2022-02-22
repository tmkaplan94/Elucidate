/*
 * Author: Grant Reed
 * Contributors: 
 * Description: Very simple class. It connects to the photon network with default settings, joins a lobby, and calls a game event
 *              to let the game manager know. It sits on an object in a loading scene whos only purpose is to load the next scene
 *              with the user connected to the network.
 */
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        GameEventBus.Start?.Invoke();
    }
}
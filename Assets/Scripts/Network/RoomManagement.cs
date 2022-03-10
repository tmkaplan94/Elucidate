/*
 * Author: Grant Reed
 * Contributors:
 * Description: This class allows players to join a room in the network. It does not really manage or 
 *              maintain any rooms, since there is no reason to yet.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class RoomManagement : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _createInput;
    [SerializeField] private InputField _joinInput;
    [SerializeField] private GameObject lobbyMenu;
    [SerializeField] private GameObject roomMenu;
    [SerializeField] private Text roomName;
    [SerializeField] private PlayerItem playerItem;
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private InputField userNameInput;
    [SerializeField] GameObject startGameButton;
    [SerializeField] Text waitingText;

    private List<PlayerItem> playerItemList = new List<PlayerItem>();

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            startGameButton.SetActive(true);
            waitingText.text = "You are the host. Start the game when ready.";
        }
        else
        {
            startGameButton.SetActive(false);
            waitingText.text = "Waiting for the host to start the game...";
        }
    }
    public void CreateRoom()
    {
        if(_createInput.text.Length >=1)
            PhotonNetwork.CreateRoom(_createInput.text);
        _joinInput.text = _createInput.text;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        lobbyMenu.SetActive(false);
        roomMenu.SetActive(true);
        roomName.text = _joinInput.text;
        UpdatePlayerList();
        //PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex +1);
    }

    private void UpdatePlayerList()
    {
        foreach(PlayerItem item in playerItemList)
        {
            Destroy(item.gameObject);
        }
        playerItemList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
            return;
        int i = 1;
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayer =  Instantiate(playerItem, scrollViewContent);
            newPlayer.SetPlayerName(player.Value);
            playerItemList.Add(newPlayer);
            i++;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public void ChangePlayerName()
    {
        PhotonNetwork.NickName = userNameInput.text;
        photonView.RPC("ChangePlayerNameRPC", RpcTarget.All);
    }

    [PunRPC]
    private void ChangePlayerNameRPC()
    {
        UpdatePlayerList();
    }

    public void OnClickStart()
    {
        photonView.RPC("ChangeCrosshairRPC", RpcTarget.All);
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    [PunRPC]
    private void ChangeCrosshairRPC()
    {
        GameEventBus.Crosshair?.Invoke();
    }
}
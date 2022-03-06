using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviour
{
    [SerializeField]
    private Text playerName;

    public void SetPlayerName(Player _player)
    {
        playerName.text = _player.NickName;
    }
}

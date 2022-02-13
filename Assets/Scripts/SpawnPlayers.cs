using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    Transform[] spawnPoints;

    private void OnEnable()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[0].position, spawnPoints[0].rotation);
    }
}

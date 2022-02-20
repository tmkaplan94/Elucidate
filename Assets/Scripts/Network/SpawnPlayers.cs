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
        int place = Random.Range(0, 5);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[place].position, spawnPoints[place].rotation);
    }
}

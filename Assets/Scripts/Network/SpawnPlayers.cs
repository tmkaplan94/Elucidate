using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] Transform[] spawnPoints;

    private void OnEnable()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[0].position, spawnPoints[0].rotation);
            }
        }
    }

    private int ChooseSpawn()
    {
        return Random.Range(0, spawnPoints.Length);
    }
}

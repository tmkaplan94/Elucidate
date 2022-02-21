using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnRobots : MonoBehaviour
{
    [SerializeField]
    private GameObject[] robotPrefabs;
    [SerializeField]
    private Transform[] spawnPoints;

    private void OnEnable()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(robotPrefabs[RandomRobot()].name, spawnPoints[i].position, spawnPoints[i].rotation);
            }
        }
    }

    private int RandomRobot()
    {
        return Random.Range(0, robotPrefabs.Length);
    }

}

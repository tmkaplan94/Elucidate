/*
 * Author: Alex Pham
 * Contributors: Grant Reed
 * Description: This class takes an array of spawn points and instantiates player prefabs at those spawn points 
 *              based on the number of players in the server.
 *              As an added bonus, it adds random hats to players.
 */
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private Mesh[] hats;

    private int numPlayers;
    private Player[] allPlayers;
    private GameObject myCurrChar;

    private void OnEnable()
    {
        allPlayers = PhotonNetwork.PlayerList;

        foreach (Player p in allPlayers)
        {
            if (p != PhotonNetwork.LocalPlayer)
            {
               numPlayers ++; 
               if(numPlayers >= spawnPoints.Length)
               {
                    numPlayers = 0;
               }
            }
        }
        myCurrChar = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[numPlayers].position, spawnPoints[numPlayers].rotation);
        SetHat();
    }

    private void SetHat()
    {
        int numHats = Random.Range(0, 7);
        myCurrChar.transform.Find("Hat_Cap").GetComponent<MeshFilter>().sharedMesh = hats[numHats];
    }
}

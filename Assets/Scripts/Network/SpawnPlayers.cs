using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/*
 * Author: Alex Pham
 * Contributors: Grant Reed
 * Description: This class takes an array of spawn points and instantiates player prefabs at those spawn points 
 *              based on the number of players in the server.
 *              As an added bonus, it adds random hats to players.
 */
public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    Mesh[] hats;

    int numPlayers;
    Player[] allPlayers;
    GameObject myCurrChar;

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
        setHat();
    }

    private void setHat()
    {
        int numHats = Random.Range(0, 7);
        myCurrChar.transform.Find("Hat_Cap").GetComponent<MeshFilter>().sharedMesh = hats[numHats];
    }
}

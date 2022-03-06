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
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Mesh[] hats;
    private GameObject myCurrChar;
    

    private void Start()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        myCurrChar = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        SetHat();
    }

    private void SetHat()
    {
        int numHats = Random.Range(0, hats.Length);
        myCurrChar.transform.Find("Hat_Cap").GetComponent<MeshFilter>().sharedMesh = hats[numHats];
    }
}

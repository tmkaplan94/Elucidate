using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

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

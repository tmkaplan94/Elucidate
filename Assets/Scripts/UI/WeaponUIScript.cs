/*
 * Author: Loc Trinh, Grant Reed
 * Contributors: 
 * Description: Small script that handles pickup UI for each weapon by turning on or off its Canvas.
 */

using UnityEngine;
using Photon.Pun;

public class WeaponUIScript : MonoBehaviourPun
{
    [SerializeField] GameObject wepUI;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine)
        {
            wepUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine)
        {
            wepUI.SetActive(false);
        }
    }
    public void TurnOffUI()
    {
        wepUI.SetActive(false);
    }
}

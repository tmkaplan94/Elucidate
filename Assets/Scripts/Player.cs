/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: Player will automatically add/remove itself to/from specified PlayerList.
 */

using System;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerList PlayerList;
    private int _id;

    private void OnEnable()
    {
        _id = GetComponent<PhotonView>().ViewID;
        PlayerList.Add(_id, this);
    }

    private void OnDisable()
    {
        PlayerList.Remove(_id);
    }
}

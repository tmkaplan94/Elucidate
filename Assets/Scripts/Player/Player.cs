/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: Player will automatically add/remove itself to/from specified PlayerList.
 */
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSpecialList PlayerList;

    private void OnEnable()
    {
        PlayerList.Add(this);
    }

    private void OnDisable()
    {
        PlayerList.Remove(this);
    }
}

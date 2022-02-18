/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: Enables designer to create a ScriptableObject list for Players.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "Players", menuName = "ScriptableObject/List/Players")]

public class PlayerList : SOList<PlayerStats> { }

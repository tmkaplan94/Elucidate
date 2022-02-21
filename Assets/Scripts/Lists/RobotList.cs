/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Grant Reed
 * Description: Enables designer to create a ScriptableObject list for Players.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "Robots", menuName = "ScriptableObject/List/Robots")]

public class RobotList : SOList<PlayerStats> { }
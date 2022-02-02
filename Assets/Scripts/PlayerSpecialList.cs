/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: Enables designer to create a SpecialList for Players.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "Players", menuName = "ScriptableObject/SpecialListSet/Players")]

public class PlayerSpecialList : SpecialList<Player> { }

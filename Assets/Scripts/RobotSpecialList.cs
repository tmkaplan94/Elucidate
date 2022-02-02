/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: Enables designer to create a SpecialList for Robots.
 *
 * Unique function GetRobot() only used for debugging.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "Robots", menuName = "ScriptableObject/SpecialList/Robots")]
public class RobotSpecialList : SpecialList<Robot>
{
    // returns first item in SpecialList, only called in test script KillEnemyOnK.cs
    public Robot GetRobot()
    {
        if (Items.Count < 0)
        {
            Debug.LogWarning("RobotList is empty");
        }
        return Items[0];
    }
}

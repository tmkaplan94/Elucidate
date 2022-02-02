using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Robots", menuName = "ScriptableObject/SpecialList/Robots")]
public class RobotSpecialList : SpecialList<Robot>
{
    public Robot GetRobot()
    {
        if (Items.Count < 0)
        {
            Debug.LogWarning("RobotList is empty");
        }
        return Items[0];
    }
}

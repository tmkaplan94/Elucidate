/*
 * Author: Ryan Hipple, from Unite Austin 2017
 * Contributors: Tyler Kaplan
 * Description: Robot will automatically add/remove itself to/from specified RobotList.
 *
 * Count used for debugging purposes.
 */
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private RobotSpecialList RobotList;
    private int count = 0;
    private void OnEnable()
    {
        RobotList.Add(this);
        count++;
        Debug.Log(count);
    }

    private void OnDisable()
    {
        RobotList.Remove(this);
    }
}

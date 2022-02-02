/*
 * Author: Tyler Kaplan
 * Contributors:
 * Description: Attach to player to kill one enemy when k is pressed.
 *
 * Used to test killing enemies during play.
 */
using UnityEngine;

public class KillEnemyOnK : MonoBehaviour
{
    // ScriptableObject list of robots to reference
    [SerializeField] private RobotSpecialList RobotList;
    void Update()
    {
        // kills robot at position 0 in list
        if (Input.GetKeyDown(KeyCode.K))
        {
            RobotList.GetRobot().GetComponent<EnemyHealth>().Kill();
        }
    }
}

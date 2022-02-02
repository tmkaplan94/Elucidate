using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private RobotSpecialList RobotList;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Robot temp = RobotList.GetRobot();
            temp.GetComponent<EnemyHealth>().Kill();
        }
    }
}

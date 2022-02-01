using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublishWinEventOnP : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameEventBus.Publish(GameEvent.WIN);
        }
    }
}

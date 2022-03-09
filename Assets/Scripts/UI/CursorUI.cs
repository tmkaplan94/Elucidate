/*
 * Author: Loc Trinh
 * Contributors: 
 * Description: Small script that handles custom cursor UI.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUI : MonoBehaviour
{
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private GameObject _cursor;

    void OnEnable()
    {
        GameEventBus.Cursor += changeCursor;
        GameEventBus.Crosshair += changeCrosshair;
        GameEventBus.Pause += changeCursor;
        GameEventBus.Resume += changeCrosshair;

    }

    void OnDisable()
    {
        GameEventBus.Cursor -= changeCursor;
        GameEventBus.Crosshair -= changeCrosshair;
        GameEventBus.Pause -= changeCursor;
        GameEventBus.Resume -= changeCrosshair;

    }
    void Update()
    {
        Cursor.visible = false;
        Vector2 cursorPos = Input.mousePosition;
        transform.position = cursorPos;
    }

    private void changeCursor()
    {
        _crosshair.SetActive(false);
        _cursor.SetActive(true);
    }

    private void changeCrosshair()
    {
        _crosshair.SetActive(true);
        _cursor.SetActive(false);
    }
}

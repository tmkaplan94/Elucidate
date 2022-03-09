/*
 * Author: Loc Trinh
 * Contributors: 
 * Description: Small script that handles custom cursor UI and some special interactions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorUI : MonoBehaviour
{
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private GameObject _cursor;

    [SerializeField] private Sprite _unclicked;
    [SerializeField] private Sprite _clicked;
    [SerializeField] private RectTransform _scale;
    [SerializeField] private float _scaleAmountBefore;
    [SerializeField] private float _scaleAmountAfter;
    private Image _image;


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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _image = GetComponent<Image>();
    }
    void Update()
    {
        Cursor.visible = false;
        Vector2 cursorPos = Input.mousePosition;
        transform.position = cursorPos;

        if(Input.GetMouseButtonDown(0) && _cursor.activeSelf)
        {
            _image.sprite = _clicked;
            _scale.localScale = new Vector3(_scaleAmountAfter, _scaleAmountAfter, 1.0f);
        }
        else if(Input.GetMouseButtonUp(0) && _cursor.activeSelf)
        {
            _image.sprite = _unclicked;
            _scale.localScale = new Vector3(_scaleAmountBefore, _scaleAmountBefore, 1.0f);
        }
        
        else if(Input.GetMouseButtonDown(0) && !_cursor.activeSelf)
        {
            _image.sprite = _clicked;
            _scale.localScale = new Vector3(_scaleAmountAfter, _scaleAmountAfter, 1.0f);
        }
        else if(Input.GetMouseButtonUp(0) && !_cursor.activeSelf)
        {
            _image.sprite = _unclicked;
            _scale.localScale = new Vector3(_scaleAmountBefore, _scaleAmountBefore, 1.0f);
        }
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Author: Alex Pham
 * Contributors:
 * Description: Plays the Loading screen animation
 */

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadText;
    [SerializeField] private int timeBetween = 20;
    private float timer;
    void Start()
    {
        _loadText.text = "Loading.";
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        int currTime = (int)timer % timeBetween;
        switch(currTime % 3)
        {
            case 0:
                _loadText.text = "Loading.";
                break;
            case 1:
                _loadText.text = "Loading..";
                break;
            case 2:
                _loadText.text = "Loading...";
                break;
            default:
                Debug.Log("Something is wrong");
                break;
        }

    }
}

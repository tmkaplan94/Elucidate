/*
 * Author: Grant Reed
 * Contributors:
 * Description: Updates player health bar.
 */
using UnityEngine.UI;
using UnityEngine;

public class HealthSlider : Observer
{
    // editor exposed fields
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerStats stats;

    // subscribes to subject
    private void OnEnable()
    {
        uiSubject._notify += WhenNotified;
        UpdateValue();
    }

    // unsubscribes from subject
    private void OnDisable()
    {
        uiSubject._notify -= WhenNotified;
    }

    // function to be called when notified
    public override void WhenNotified(int value)
    {
        UpdateValue();
    }

    // updates health value when notified
    private void UpdateValue()
    {
        slider.value = stats.Health;
    }
}

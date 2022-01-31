using UnityEngine.UI;
using UnityEngine;

public class HealthSlider : Observer
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private PlayerStats stats;

    private void OnEnable()
    {
        stats._notify += WhenNotified;
        UpdateValue();
    }
    private void OnDisable()
    {
        stats._notify -= WhenNotified;
    }

    public override void WhenNotified(int value)
    {
        UpdateValue();
    }

    private void UpdateValue()
    {
        slider.value = stats.Health;
    }
}

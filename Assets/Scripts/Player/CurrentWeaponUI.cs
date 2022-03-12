using TMPro;
using UnityEngine;

/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: Updates UI for the current weapon of the player.
 *              It listens to the checkinput game event and gets its weapon information from player stats
 */
public class CurrentWeaponUI : MonoBehaviour
{
    //gets information from playerstats
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerInputHandler playerInput;
    private TextMeshProUGUI text;

    //subscribe on disable
    private void OnEnable()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = stats.CurrentWeapon.name;
        playerInput.CheckInteract += UpdateText;
    }
     //unsubscribe on disable
    private void OnDisable()
    {
        playerInput.CheckInteract -= UpdateText;
    }
    private void UpdateText()
    {
        text.text = stats.CurrentWeapon.name;
    }
}

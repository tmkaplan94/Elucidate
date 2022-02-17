/*
 * Author: Grant Reed, Loc Trinh
 * Contributors:
 * Description: Updates player health bar.
 */
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] PhotonView _view;
    [SerializeField]
    private Slider healthSlider;

    public void setHealth(float health)
    {
        if(_view.IsMine)
        {
            healthSlider.value = health;
        }
    }
}

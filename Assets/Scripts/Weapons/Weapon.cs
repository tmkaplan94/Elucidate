/*
 * Author: Grant Reed
 * Contributors:
 * Description: Defines information needed to create ScriptableObject weapons from editor.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObject/Weapon")]
public class Weapon : ScriptableObject
{
    public string prefabName;

    public float rpm;
    public float bulletVelocity;
    [Range(0.1f, 5.0f)]
    public float bulletSizeScale;
    public float bulletDamage;
    public Color muzzleFlashColor;
    public float muzzleFlashRange;
    public float muzzleFlashIntensity;
    public LightType muzzleFlashLightType;

    public GameObject bullet;
}

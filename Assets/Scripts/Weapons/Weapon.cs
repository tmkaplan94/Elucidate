/*
 * Author: Grant Reed
 * Contributors:
 * Description: Defines information needed to create ScriptableObject weapons from editor.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObject/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private string _prefabName;
    [SerializeField] private float _roundsPerSecond;
    [SerializeField] private float _bulletVelocity;
    [Range(0.1f, 5.0f)]
    [SerializeField] private float _bulletSizeScale;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _bulletDamage;
    [SerializeField] private Color _muzzleFlashColor;
    [SerializeField] private float _muzzleFlashRange;
    [SerializeField] private float _muzzleFlashIntensity;
    [SerializeField] private float _muzzleFlashLifeTime;
    [SerializeField] private LightType _muzzleFlashLightType;

    [SerializeField] private GameObject _bullet;

    #region parameters
    public string PrefabName
    {
        get => _prefabName;
    }
    public float RoundsPerSecond
    {
        get => _roundsPerSecond;
        set => _roundsPerSecond = value;
    }
    public float BulletVelocity
    {
        get => _bulletVelocity;
        set => _bulletVelocity = value;
    }
    public float BulletSizeScale
    {
        get => _bulletSizeScale;
        set => _bulletSizeScale = value;
    }
        public float BulletLifeTime
    {
        get => _bulletLifeTime;
        set => _bulletLifeTime = value;
    }

    public float BulletDamage
    {
        get => _bulletDamage;
        set => _bulletDamage = value;
    }
    public Color MuzzleFlashColor
    {
        get => _muzzleFlashColor;
        set => _muzzleFlashColor = value;
    }
    public float MuzzleFlashRange
    {
        get => _muzzleFlashRange;
        set => _muzzleFlashRange = value;
    }
    public float MuzzleFlashIntensity
    {
        get => _muzzleFlashIntensity;
        set => _muzzleFlashIntensity = value;
    }
    public float MuzzleFlashLifeTime
    {
        get => _muzzleFlashLifeTime;
        set => _muzzleFlashLifeTime = value;
    }
    public LightType MuzzleFlashLightType
    {
        get => _muzzleFlashLightType;
        set => _muzzleFlashLightType = value;
    }
    public GameObject Bullet
    {
        get => _bullet;
        set => _bullet = value;
    }
    #endregion
}

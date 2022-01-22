using UnityEngine;

/**
 * version 1.0
 * Date: 1/22/2022
 * Description: Defines information needed for Weapon objects
 * 
 * Notes: 1.0 Added basic information for a family of objects.
 *
 *        
 * Author: Grant Reed
 * Contributors:
 * 
 */

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public string prefabName;

    public float rpm;
    public float bulletVelocity;
    [Range(0.1f, 5.0f)]
    public float bulletSizeScale;
    public float bulletDamage;

    public GameObject bullet;
    
}

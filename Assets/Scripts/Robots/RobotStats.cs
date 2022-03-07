/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Enables designer to create new AIStats ScriptableObject.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "RobotStats", menuName = "ScriptableObject/RobotStats")]
public class RobotStats : ScriptableObject
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isConstantlyWalking;
    [SerializeField] private float detectRadius;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float maxHealth;

    #region Properties

    public float MovementSpeed => movementSpeed;
    public float RotationSpeed => rotationSpeed;
    public bool IsConstantlyWalking => isConstantlyWalking;
    public float DetectRadius => detectRadius;
    public float ShootingSpeed => shootingSpeed;
    public float BulletDamage => bulletDamage;
    public float MaxHealth => maxHealth;

    #endregion
}
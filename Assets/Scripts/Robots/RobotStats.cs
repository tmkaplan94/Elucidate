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
    [SerializeField] private float approachRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float maxHealth;

    #region Properties

    public float MovementSpeed => movementSpeed;
    public float RotationSpeed => rotationSpeed;
    public bool IsConstantlyWalking => isConstantlyWalking;
    public float ApproachRadius => approachRadius;
    public float AttackRadius => attackRadius;
    public float ShootingSpeed => shootingSpeed;
    public float BulletDamage => bulletDamage;
    public float MaxHealth => maxHealth;

    #endregion
}
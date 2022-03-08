/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Enables designer to create new AIStats ScriptableObject.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "RobotStats", menuName = "ScriptableObject/RobotStats")]
public class RobotStats : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float approachRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private int fleeCooldown;

    #region Properties

    public float MaxHealth => maxHealth;
    public float MovementSpeed => movementSpeed;
    public float ApproachRadius => approachRadius;
    public float AttackRadius => attackRadius;
    public float ShootingSpeed => shootingSpeed;
    public float BulletDamage => bulletDamage;
    public int FleeCooldown => fleeCooldown;

    #endregion
}
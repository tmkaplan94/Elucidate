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
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private int shootingCooldown;
    [SerializeField] private int fleeCooldown;
    [SerializeField] private int rotationSpeed;

    #region Properties

    public float MaxHealth => maxHealth;
    public float MovementSpeed => movementSpeed;
    public float ApproachRadius => approachRadius;
    public float AttackRadius => attackRadius;
    public GameObject BulletPrefab => bulletPrefab;
    public float BulletSpeed => bulletSpeed;
    public float BulletDamage => bulletDamage;
    public int ShootingCooldown => shootingCooldown;
    public int FleeCooldown => fleeCooldown;
    public int RotationSpeed => rotationSpeed;

    #endregion
}
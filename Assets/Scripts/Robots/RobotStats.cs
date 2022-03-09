/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Enables designer to create new SO stats for robots.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "RobotStats", menuName = "ScriptableObject/Stats/Robot")]
public class RobotStats : ScriptableObject
{ 
    [SerializeField] private float maxHealth;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float approachRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float collisionDamage;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private int tacticalCooldown;
    [SerializeField] private int shootingCooldown;
    [SerializeField] private int fleeingCooldown;
    [SerializeField] private int strafingCooldown;
    
    [RangedIntMinMax(1,360)]
    public RangedInt strafingSpeed;

    #region Properties

    public float MaxHealth => maxHealth;
    public float MovementSpeed => movementSpeed;
    public float ApproachRadius => approachRadius;
    public float AttackRadius => attackRadius;
    public float CollisionDamage => collisionDamage;
    public GameObject BulletPrefab => bulletPrefab;
    public float BulletSpeed => bulletSpeed;
    public float BulletDamage => bulletDamage;
    public int TacticalCooldown => tacticalCooldown;
    public int ShootingCooldown => shootingCooldown;
    public int FleeingCooldown => fleeingCooldown;
    public int StrafingCooldown => strafingCooldown;

    #endregion

}
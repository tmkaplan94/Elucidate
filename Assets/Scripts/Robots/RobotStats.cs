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
    [SerializeField] private int collisionForce;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private int shootingSpeed;   // measured in (500 - input) frames
    [SerializeField] private int tacticalDuration; // times 10, measured in frames
    [SerializeField] private int fleeingDuration;  // times 10, measured in frames
    [SerializeField] private int strafingReset;     // times 10, measured in frames
    [SerializeField] private int strafingSpeed;    // measured in degrees per second

    #region Properties

    public float MaxHealth => maxHealth;
    public float MovementSpeed => movementSpeed;
    public float ApproachRadius => approachRadius;
    public float AttackRadius => attackRadius;
    public float CollisionDamage => collisionDamage;
    public int CollisionForce => collisionForce;
    public GameObject BulletPrefab => bulletPrefab;
    public float BulletSpeed => bulletSpeed;
    public float BulletDamage => bulletDamage;
    public int ShootingSpeed => shootingSpeed;
    public int TacticalDuration => tacticalDuration;
    public int FleeingDuration => fleeingDuration;
    public int StrafingReset => strafingReset;
    public int StrafingSpeed => strafingSpeed;

    #endregion

}
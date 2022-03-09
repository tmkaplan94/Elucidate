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
    [RangedIntMinMax(200,460)] public RangedInt shootingSpeed;
    [RangedIntMinMax(400,1000)] public RangedInt tacticalTimer; // measured in frames
    [SerializeField] private int fleeingCooldown;
    [SerializeField] private int strafingCooldown;
    [RangedIntMinMax(20,100)] public RangedInt strafingSpeed;   // measured in degrees per second

    #region Properties

    public float MaxHealth => maxHealth;
    public float MovementSpeed => movementSpeed;
    public float ApproachRadius => approachRadius;
    public float AttackRadius => attackRadius;
    public float CollisionDamage => collisionDamage;
    public GameObject BulletPrefab => bulletPrefab;
    public float BulletSpeed => bulletSpeed;
    public float BulletDamage => bulletDamage;
    public int FleeingCooldown => fleeingCooldown;
    public int StrafingCooldown => strafingCooldown;

    #endregion

}
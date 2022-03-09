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
    [RangedIntMinMax(200,460)] public RangedInt shootingSpeed;  // measured in (500 - input) frames
    [RangedIntMinMax(400,1000)] public RangedInt tacticalTimer; // measured in frames
    [RangedIntMinMax(200,1000)] public RangedInt fleeingTimer;  // measured in frames
    [RangedIntMinMax(200,800)] public RangedInt strafingTimer;  // measured in frames
    [RangedIntMinMax(20,100)] public RangedInt strafingSpeed;   // measured in degrees per second

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

    #endregion

}
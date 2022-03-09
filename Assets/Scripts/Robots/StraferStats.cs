/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Enables designer to create SO stats for Strafer robot.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "StraferStats", menuName = "ScriptableObject/RobotStats")]
public class StraferStats : RobotStats
{
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;
         
    [SerializeField] private float movementSpeed;
    public float MovementSpeed => movementSpeed;
         
    [SerializeField] private float approachRadius;
    public float ApproachRadius => approachRadius;
         
    [SerializeField] private float attackRadius;
    public float AttackRadius => attackRadius;
         
    [SerializeField] private GameObject bulletPrefab;
    public GameObject BulletPrefab => bulletPrefab;
    
    [SerializeField] private Transform firepoint;
    public Transform FirePoint => firepoint;
         
    [SerializeField] private float bulletSpeed;
    public float BulletSpeed => bulletSpeed;
         
    [SerializeField] private float bulletDamage;
    public float BulletDamage => bulletDamage;
         
    [SerializeField] private int shootingCooldown;
    public int ShootingCooldown => shootingCooldown;
    
    [SerializeField] private int strafingCooldown;
    public int StrafingCooldown => strafingCooldown;
    
    [RangedIntMinMax(1,360)]
    public RangedInt strafingSpeed;
}
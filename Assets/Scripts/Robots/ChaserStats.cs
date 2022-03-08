﻿/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Enables designer to create SO stats for Chaser robot.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "ChaserStats", menuName = "ScriptableObject/RobotStats")]
public class ChaserStats : MonoBehaviour
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
    
    [SerializeField] private float bulletSpeed;
    public float BulletSpeed => bulletSpeed;
    
    [SerializeField] private float bulletDamage;
    public float BulletDamage => bulletDamage;
    
    [SerializeField] private int shootingCooldown;
    public int ShootingCooldown => shootingCooldown;
}
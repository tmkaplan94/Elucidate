/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Enables designer to create SO stats for Chicken robot.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "ChickenStats", menuName = "ScriptableObject/RobotStats")]
public class ChickenStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;
         
    [SerializeField] private float movementSpeed;
    public float MovementSpeed => movementSpeed;
         
    [SerializeField] private float approachRadius;
    public float ApproachRadius => approachRadius;
    
    [SerializeField] private float fleeRadius;
    public float FleeRadius => fleeRadius;
    
    [SerializeField] private int fleeCooldown;
    public int FleeCooldown => fleeCooldown;
}
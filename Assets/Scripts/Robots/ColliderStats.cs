/*
 * Author: Brian Caballero
 * Contributors: Grant Reed, Tyler Kaplan
 * Description: Enables designer to create SO stats for Collider robot.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "ColliderStats", menuName = "ScriptableObject/RobotStats")]
public class ColliderStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;
              
    [SerializeField] private float movementSpeed;
    public float MovementSpeed => movementSpeed;
              
    [SerializeField] private float approachRadius;
    public float ApproachRadius => approachRadius;

    [SerializeField] private int fleeCooldown;
    public int FleeCooldown => fleeCooldown;
}
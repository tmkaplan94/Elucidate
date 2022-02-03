/*
 * Author: Brian Caballero
 * Contributors:
 * Description: Enables designer to create new AIStat ScriptableObject.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "AIStats", menuName = "ScriptableObject/AIStats")]
public class AIStats : ScriptableObject
{
    public AIState CurrentState;
    public float MovementSpeed;
    public float RotationSpeed;
    public bool IsConstantlyWalking;
    public float DetectRadius;
    public float ShootingSpeed;

    public enum AIState
    {
        Wandering,
        Patrolling,
        Sprinting,
        RunNGun,
        Camping
    }
}
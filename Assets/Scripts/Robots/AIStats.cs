/*
 * Author: Brian Caballero
 * Contributors:
 * Description: Enables designer to create new AIStats ScriptableObject.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "AIStats", menuName = "ScriptableObject/AIStats")]
public class AIStats : ScriptableObject
{
    public AIState currentState;
    public float movementSpeed;
    public float rotationSpeed;
    public bool isConstantlyWalking;
    public float detectRadius;
    public float shootingSpeed;
}
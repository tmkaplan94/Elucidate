/*
 * Author: Brian Caballero
 * Contributors: Grant Reed
 * Description: Enables designer to create new AIStats ScriptableObject.
 */
using UnityEngine;

[CreateAssetMenu(fileName = "AIStats", menuName = "ScriptableObject/AIStats")]
public class AIStats : ScriptableObject
{
    [SerializeField] private AIState currentState;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isConstantlyWalking;
    [SerializeField] private float detectRadius;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float bulletDamage;

#region
    public AIState CurrentState
    {
        get => currentState;
        set => currentState = value;
    }
    public float MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }
   public float RotationSpeed
    {
        get => rotationSpeed;
        set => rotationSpeed = value;
    }
   public bool IsConstantlyWalking
    {
        get => isConstantlyWalking;
        set => isConstantlyWalking = value;
    }
   public float DetectRadius
    {
        get => detectRadius;
        set => detectRadius = value;
    }
   public float ShootingSpeed
    {
        get => shootingSpeed;
        set => shootingSpeed = value;
    }
   public float BulletDamage
    {
        get => bulletDamage;
        set => bulletDamage = value;
    }
    #endregion
}
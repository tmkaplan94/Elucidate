using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIStats", menuName = "ScriptableObjects/AIStats")]
public class AIStats : ScriptableObject
{
    public AI_State CurrentState;
    public float MovementSpeed;
    public float RotationSpeed;
    public bool IsConstantlyWalking;
    public float DetectRadius;
    public float ShootingSpeed;

    public enum AI_State
    {
        Wandering,
        Patroling,
        Sprinting,
        RunNGuning,
        Camping
    }
}
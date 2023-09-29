using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NEW StateMachineScriptableObject", menuName = "ScriptableObjects/StateMachineScriptableObject")]
public class StateMachineScriptableObject : ScriptableObject
{
    public int normalDifficultyTime = 180;
    public int hardDifficultyTime = 60;

    public float normalCoefficient = 2;
    public float hardCoefficient = 3;
    public int maxValue = 5;
    public int minValue = -5;

    public float maxAirCapacity = 100F;
}

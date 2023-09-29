using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "NEW DifficultyScriptableObject", menuName = "ScriptableObjects/DifficultyScriptableObject")]
public class DifficultyScriptableObject : ScriptableObject
{
    public int maxValue = 5;
    public int minValue = -5;
    public int normalDifficultyTime = 180;
    public int hardDifficultyTime = 60;

    public float easyCoefficient = 1;
    public float normalCoefficient=2;
    public float hardCoefficient=3;

    
}

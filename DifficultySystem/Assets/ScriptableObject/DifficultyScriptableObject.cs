using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NEW DifficultyScriptableObject", menuName = "ScriptableObjects/DifficultyScriptableObject")]
public class DifficultyScriptableObject : ScriptableObject
{
    public bool easy;
    public bool normal;
    public bool hard;

    public int maxValue = 5;
    public int minValue = -5;

}

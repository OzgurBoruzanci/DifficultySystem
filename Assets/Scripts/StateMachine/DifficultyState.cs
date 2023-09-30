using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DifficultyState : MonoBehaviour
{
    [SerializeField] protected DifficultyScriptableObject difficultyScriptableObject;
    protected DifficultyState nextState;

    protected int maxValue;
    protected int minValue;
    public abstract DifficultyState DifficultySituation(TimerManager timer);

    protected void NextDifficultyState(DifficultyState state)
    {
        nextState = state;
    }
    protected void StartMethod()
    {
        maxValue = difficultyScriptableObject.maxValue;
        minValue = difficultyScriptableObject.minValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DifficultyState : MonoBehaviour
{
    [SerializeField] protected StateMachineScriptableObject stateMachineScriptableObject;
    protected DifficultyState nextState;

    [SerializeField] protected int maxValue;
    [SerializeField] protected int minValue;
    protected int nextDifficultyTime;
    protected bool thisState = true;
    public abstract DifficultyState DifficultySituation(TimerManager timer);
    protected void StartMethod()
    {
        maxValue = stateMachineScriptableObject.maxValue;
        minValue = stateMachineScriptableObject.minValue;
    }
    protected void NextDifficultyState(DifficultyState state)
    {
        nextState = state;
    }
}

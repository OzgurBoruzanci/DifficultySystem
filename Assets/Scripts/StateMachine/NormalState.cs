using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : DifficultyState
{
    [SerializeField] float _coefficient = 2f;

    private void OnEnable()
    {
        EventManager.DifficultyStateHard += NextDifficultyState;
    }
    private void OnDisable()
    {
        EventManager.DifficultyStateHard -= NextDifficultyState;
    }
    

    public override DifficultyState DifficultySituation(TimerManager timer)
    {
        if (timer.timeRemaining <= nextDifficultyTime)
        {
            return nextState;
        }
        if (thisState)
        {
            thisState = false;
            maxValue = (int)Math.Round(maxValue * _coefficient);
            minValue = (int)Math.Round(minValue * _coefficient);
        }
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateNormal(this);
        StartMethod();
        nextDifficultyTime = stateMachineScriptableObject.hardDifficultyTime;
        _coefficient = stateMachineScriptableObject.normalCoefficient;
    }

}

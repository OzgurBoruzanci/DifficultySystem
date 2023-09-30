using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardState : DifficultyState
{    
    [SerializeField] float _coefficient = 3f;

    private void OnEnable()
    {
        EventManager.DifficultyStateEasy += NextDifficultyState;
    }
    private void OnDisable()
    {
        EventManager.DifficultyStateEasy -= NextDifficultyState;
    }

    public override DifficultyState DifficultySituation(TimerManager timer)
    {
        if (timer.timeRemaining <= 0f)
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
        EventManager.DifficultyStateHard(this);
        StartMethod();
        _coefficient = stateMachineScriptableObject.hardCoefficient;
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardState : DifficultyState
{
    float _coefficient = 2f;
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
        difficultyScriptableObject.maxValue = (int)Math.Round(maxValue * _coefficient);
        difficultyScriptableObject.minValue = (int)Math.Round(minValue * _coefficient);
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateHard(this);
        StartMethod();
    }

    
}

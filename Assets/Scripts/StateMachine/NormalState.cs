using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : DifficultyState
{
    float _coefficient = 1.5f;
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
        if (timer.timeRemaining <= 60f)
        {
            return nextState;
        }
        difficultyScriptableObject.maxValue = (int)Math.Round(maxValue * _coefficient);
        difficultyScriptableObject.minValue = (int)Math.Round(minValue * _coefficient);
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateNormal(this);
        StartMethod();
    }

}

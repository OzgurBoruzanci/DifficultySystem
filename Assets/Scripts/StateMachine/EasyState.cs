using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyState : DifficultyState
{
    private void OnEnable()
    {
        EventManager.DifficultyStateNormal += NextDifficultyState;
    }
    private void OnDisable()
    {
        EventManager.DifficultyStateNormal -= NextDifficultyState;
    }

    public override DifficultyState DifficultySituation(TimerManager timer)
    {
        if (timer.timeRemaining <= nextDifficultyTime)
        {
            return nextState;
        }
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateEasy(this);
        StartMethod();
        nextDifficultyTime = stateMachineScriptableObject.normalDifficultyTime;
    }

    
}

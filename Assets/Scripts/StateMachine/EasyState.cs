using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyState : DifficultyState
{
    [SerializeField]
    StateMachineScriptableObject _stateMachineScriptableObject;
    DifficultyState _normalState;

    [SerializeField]int _maxValue;
    [SerializeField] int _minValue;
    int _normalDifficultyTime;
    
    private void OnEnable()
    {
        EventManager.DifficultyStateNormal += DifficultyStateNormal;
    }
    private void OnDisable()
    {
        EventManager.DifficultyStateNormal -= DifficultyStateNormal;
    }
    void DifficultyStateNormal(DifficultyState state)
    {
        _normalState = state;
    }

    public override DifficultyState DifficultySituation(TimerManager timer)
    {
        if (timer.timeRemaining <= _normalDifficultyTime)
        {
            return _normalState;
        }
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateEasy(this);
        _maxValue = _stateMachineScriptableObject.maxValue;
        _minValue = _stateMachineScriptableObject.minValue;
        _normalDifficultyTime = _stateMachineScriptableObject.normalDifficultyTime;
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardState : DifficultyState
{
    [SerializeField]
    StateMachineScriptableObject _stateMachineScriptableObject;
    DifficultyState _easyState;

    [SerializeField] int _maxValue;
    [SerializeField] int _minValue;
    [SerializeField] float _coefficient = 3f;

    bool _hard = true;

    private void OnEnable()
    {
        EventManager.DifficultyStateEasy += DifficultyStateEasy;
    }
    private void OnDisable()
    {
        EventManager.DifficultyStateEasy -= DifficultyStateEasy;
    }
    void DifficultyStateEasy(DifficultyState state)
    {
        _easyState = state;
    }

    public override DifficultyState DifficultySituation(TimerManager timer)
    {
        if (timer.timeRemaining <= 0f)
        {
            return _easyState;
        }
        if (_hard)
        {
            _hard=false;
            _maxValue = (int)Math.Round(_maxValue * _coefficient);
            _minValue = (int)Math.Round(_minValue * _coefficient);
        }
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateHard(this);
        _maxValue = _stateMachineScriptableObject.maxValue;
        _minValue = _stateMachineScriptableObject.minValue;
        _coefficient = _stateMachineScriptableObject.hardCoefficient;
    }

    
}

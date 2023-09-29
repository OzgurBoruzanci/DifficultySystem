using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : DifficultyState
{
    [SerializeField]
    StateMachineScriptableObject _stateMachineScriptableObject;
    DifficultyState _hardState;

    [SerializeField] int _maxValue;
    [SerializeField] int _minValue;
    int _hardDifficultyTime;

    bool _normal = true;

    [SerializeField] float _coefficient = 2f;

    private void OnEnable()
    {
        EventManager.DifficultyStateHard += DifficultyStateHard;
    }
    private void OnDisable()
    {
        EventManager.DifficultyStateHard -= DifficultyStateHard;
    }
    void DifficultyStateHard(DifficultyState state)
    {
        _hardState = state;
    }

    public override DifficultyState DifficultySituation(TimerManager timer)
    {
        if (timer.timeRemaining <= _hardDifficultyTime)
        {
            return _hardState;
        }
        if (_normal)
        {
            _normal = false;
            _maxValue = (int)Math.Round(_maxValue * _coefficient);
            _minValue = (int)Math.Round(_minValue * _coefficient);
        }
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateNormal(this);
        _maxValue = _stateMachineScriptableObject.maxValue;
        _minValue = _stateMachineScriptableObject.minValue;
        _hardDifficultyTime = _stateMachineScriptableObject.hardDifficultyTime;
        _coefficient = _stateMachineScriptableObject.normalCoefficient;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : DifficultyState
{
    [SerializeField]
    DifficultyScriptableObject _difficultyScriptableObject;
    DifficultyState _hardState;

    int _maxValue;
    int _minValue;
    float _coefficient = 1.5f;
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
        if (timer.timeRemaining <= 60f)
        {
            return _hardState;
        }
        _difficultyScriptableObject.maxValue = (int)Math.Round(_maxValue * _coefficient);
        _difficultyScriptableObject.minValue = (int)Math.Round(_minValue * _coefficient);
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateNormal(this);
        _maxValue = _difficultyScriptableObject.maxValue;
        _minValue = _difficultyScriptableObject.minValue;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardState : DifficultyState
{
    [SerializeField]
    DifficultyScriptableObject _difficultyScriptableObject;
    DifficultyState _easyState;

    int _maxValue;
    int _minValue;
    float _coefficient = 2f;
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
        _difficultyScriptableObject.maxValue = (int)Math.Round(_maxValue * _coefficient);
        _difficultyScriptableObject.minValue = (int)Math.Round(_minValue * _coefficient);
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateHard(this);
        _maxValue = _difficultyScriptableObject.maxValue;
        _minValue = _difficultyScriptableObject.minValue;
    }

    
}

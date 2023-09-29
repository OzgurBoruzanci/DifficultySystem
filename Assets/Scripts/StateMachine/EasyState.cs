using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyState : DifficultyState
{
    [SerializeField]
    DifficultyScriptableObject _difficultyScriptableObject;
    DifficultyState _normalState;

    int _maxValue;
    int _minValue;

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
        if (timer.timeRemaining <= 180f)
        {
            return _normalState;
        }
        _difficultyScriptableObject.maxValue = _maxValue;
        _difficultyScriptableObject.minValue= _minValue;
        return this;
    }

    
    void Start()
    {
        EventManager.DifficultyStateEasy(this);
        _maxValue = _difficultyScriptableObject.maxValue;
        _minValue = _difficultyScriptableObject.minValue;
    }

    
}

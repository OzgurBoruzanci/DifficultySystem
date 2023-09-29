using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] DifficultyState _currentState;
    [SerializeField] TimerManager timerManager;

    
    void Update()
    {
        DifficultyStateMachine();
    }

    void DifficultyStateMachine()
    {
        DifficultyState state = _currentState.DifficultySituation(timerManager);
        if (_currentState != null)
        {
            _currentState = state;
        }
    }
}

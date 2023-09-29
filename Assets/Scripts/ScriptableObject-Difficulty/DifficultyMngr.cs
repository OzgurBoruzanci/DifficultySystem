using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DifficultyScriptableObject;

public class DifficultyMngr : MonoBehaviour
{
    [SerializeField] DifficultyScriptableObject difficultyScriptableObject;
    [SerializeField] TimerManager timerManager;
    [SerializeField] enum Difficulty { Easy, Normal, Hard };
    [SerializeField] Difficulty difficulty;

    [SerializeField] int _maxValue;
    [SerializeField] int _minValue;
    int _normalDifficultyTime;
    int _hardDifficultyTime;

    bool easy = false;
    bool normal = false;
    bool hard = false;

    void Start()
    {
        _maxValue = difficultyScriptableObject.maxValue;
        _minValue = difficultyScriptableObject.minValue;
        _normalDifficultyTime= difficultyScriptableObject.normalDifficultyTime;
        _hardDifficultyTime= difficultyScriptableObject.hardDifficultyTime;
    }

    
    void Update()
    {
        DifficultyControl();
        //DifficultyChoice();
    }
    void DifficultyControl()
    {
        if (timerManager.timeRemaining > _normalDifficultyTime && !easy)
        {
            difficulty = Difficulty.Easy;
            DifficultyChoice();
            easy = true;
        }
        else if (timerManager.timeRemaining <= _normalDifficultyTime && !normal)
        {
            difficulty = Difficulty.Normal;
            DifficultyChoice();
            normal = true;
        }
        else if (timerManager.timeRemaining <= _hardDifficultyTime && !hard)
        {
            difficulty = Difficulty.Hard;
            DifficultyChoice();
            hard = true;
        }
    }
    public void DifficultyChoice()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                _maxValue= (int)Math.Round(_maxValue * difficultyScriptableObject.easyCoefficient);
                _minValue = (int)Math.Round(_minValue * difficultyScriptableObject.easyCoefficient);
                break;
            case Difficulty.Normal:
                _minValue = (int)Math.Round(_minValue * difficultyScriptableObject.normalCoefficient);
                _maxValue = (int)Math.Round(_maxValue * difficultyScriptableObject.normalCoefficient);
                break;
            case Difficulty.Hard:
                _minValue = (int)Math.Round(_minValue * difficultyScriptableObject.hardCoefficient);
                _maxValue = (int)Math.Round(_maxValue * difficultyScriptableObject.hardCoefficient);
                break;
        }
    }
}

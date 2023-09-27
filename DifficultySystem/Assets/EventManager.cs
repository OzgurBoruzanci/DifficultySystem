using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action<DifficultyState> DifficultyStateEasy;
    public static Action<DifficultyState> DifficultyStateNormal;
    public static Action<DifficultyState> DifficultyStateHard;
}
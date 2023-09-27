using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DifficultyState : MonoBehaviour
{
    public abstract DifficultyState DifficultySituation(TimerManager timer);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWonState : State
{
    protected override void OnEnter()
    {
        base.OnEnter();
        StartCoroutine(WaitBeforeMovingToNextLevel(2));
    }

    IEnumerator WaitBeforeMovingToNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameData.IncreaseScore();
        LevelTransitionsManager.thisInstance.NextLevel();
    }
}

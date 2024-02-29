using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverState : State
{
    [SerializeField] UnityEvent onEnter;

    protected override void OnEnter()
    {
        onEnter.Invoke();
        ShowGameOverScreen();
        HUD.thisInstance.ToggleGameCurrentScoreVisibility(false);
    }

    protected override void OnExit()
    {
        base.OnExit();
        StopAllCoroutines();
    }

    void ShowGameOverScreen()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        HUD.thisInstance.ShowGameOverScore(GameData.currentScore, GameData.highScore);
    }
}

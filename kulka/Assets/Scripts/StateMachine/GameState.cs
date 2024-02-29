using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : State
{
    [SerializeField] private ShootingSystem shootingSystem;
    [SerializeField] private UnityEvent onEnter;
    [SerializeField] private GroundGenerationSettings groundGenerationSettings;


    protected override void OnEnter()
    {
        base.OnEnter();
        shootingSystem.ModifyLaunchSpeedGrowthMultiplier(GameData.currentScore);
        GroundGenerator.GenerateGround(groundGenerationSettings);
        HUD.thisInstance.SetGameCurrentScore(GameData.currentScore);
        HUD.thisInstance.ToggleCurbain(false);
        onEnter.Invoke();
    }

    protected override void OnExit()
    {
        base.OnExit();
    }

    public void SwitchToGameOverScene()
    {
        sc.ChangeState(sc.gameOverState);
    }
    public void SwitchToLevelWonScene()
    {
        sc.ChangeState(sc.levelWonState);
    }
}

using UnityEngine;

public class FinalState : GameStateBase
{
    private readonly PlayerStateMachine _playerStateMachine;
    private readonly PlayerMovement _playerMovement;

    public FinalState(Bootstrapper bootstrapper, PlayerStateMachine playerStateMachine, PlayerMovement playerMovement) 
        : base(bootstrapper, null)
    {
        _playerStateMachine = playerStateMachine;
        _playerMovement = playerMovement;
    }

    public override void Enter()
    {
        base.Enter();
        
        _playerStateMachine.SetState<FinalPlayerState>();

        _playerMovement.DisableMovement();

        Time.timeScale = 1.0f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }

    protected override void UpdateHUDState()
    {
        HUDController.Instance.UpdateStateText("Final State - Game Over - No Return");
    }
}
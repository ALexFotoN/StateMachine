using UnityEngine;

public class GameState : GameStateBase
{
    private readonly PlayerMovement _playerMovement;

    public GameState(Bootstrapper bootstrapper, IInputService inputService, PlayerMovement playerMovement) 
        : base(bootstrapper, inputService)
    {
        _playerMovement = playerMovement;
    }

    public override void Enter()
    {
        base.Enter();
        
        _playerMovement.EnableMovement();
        
        if (InputService is PlayerInput playerInput)
        {
            playerInput.EnableInput();
        }
        
        Time.timeScale = 1.0f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        var playerStateMachine = Bootstrapper.GetPlayerStateMachine();
        playerStateMachine?.Update();

        if (InputService.IsPauseButtonDown)
        {
            GameStateMachine.Instance.SetState<PauseState>();
        }

        if (InputService.IsExitButtonDown)
        {
            GameStateMachine.Instance.SetState<FinalState>();
        }
    }

    protected override void UpdateHUDState()
    {
        HUDController.Instance.UpdateStateText("Game State - Playing");
    }
}
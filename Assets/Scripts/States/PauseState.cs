using UnityEngine;

public class PauseState : GameStateBase
{
    public PauseState(Bootstrapper bootstrapper, IInputService inputService) 
        : base(bootstrapper, inputService)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        Time.timeScale = 0.0f;
        
        if (InputService is PlayerInput playerInput)
        {
            playerInput.DisableInput();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        if (InputService.IsPauseButtonDown)
        {
            GameStateMachine.Instance.SetState<GameState>();
        }
        
        if (InputService.IsExitButtonDown)
        {
            GameStateMachine.Instance.SetState<FinalState>();
        }
    }

    protected override void UpdateHUDState()
    {
        HUDController.Instance.UpdateStateText("Pause State - Game Paused - Press Space to Resume");
    }
}
using UnityEngine;

public abstract class GameStateBase : IState
{
    protected readonly Bootstrapper Bootstrapper;
    protected readonly IInputService InputService;

    protected GameStateBase(Bootstrapper bootstrapper, IInputService inputService)
    {
        Bootstrapper = bootstrapper;
        InputService = inputService;
    }

    public virtual void Enter()
    {
        UpdateHUDState();
    }

    public virtual void Exit() { }

    public virtual void Update() { }

    protected abstract void UpdateHUDState();
}
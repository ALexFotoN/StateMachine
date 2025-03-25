// Измените класс PlayerState.cs
using UnityEngine;

public abstract class PlayerState : IState
{
    private readonly IInputService _inputService;
    protected readonly PlayerCombat PlayerCombat;

    protected PlayerState(IInputService inputService, PlayerCombat playerCombat)
    {
        _inputService = inputService;
        PlayerCombat = playerCombat;
    }

    public virtual void Enter()
    {
        UpdateHUDState();
    }

    public virtual void Exit() { }

    public virtual void Update()
    {
        if (_inputService.IsAttackButtonDown)
        {
            OnAttack();
        }
    }

    protected abstract void OnAttack();
    protected abstract void UpdateHUDState();
}
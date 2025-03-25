using UnityEngine;

public class FinalPlayerState : PlayerState
{
    public FinalPlayerState(IInputService inputService, PlayerCombat playerCombat) 
        : base(inputService, playerCombat)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerCombat.ToggleRedZone(false);
        PlayerCombat.SetTransparency(1f);
        PlayerCombat.SetColor(Color.green);
    }

    public override void Update()
    {

    }

    protected override void OnAttack()
    {

    }

    protected override void UpdateHUDState()
    {
        HUDController.Instance.UpdateStateText("Final State - Game Over");
    }
}
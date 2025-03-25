using UnityEngine;

public class RedZoneState : PlayerState
{
    private bool _isRedZoneActive;

    public RedZoneState(IInputService inputService, PlayerCombat playerCombat) 
        : base(inputService, playerCombat)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _isRedZoneActive = false;
        PlayerCombat.ToggleRedZone(false);
        PlayerCombat.SetTransparency(1f);
        PlayerCombat.SetColor(Color.white);
    }

    public override void Exit()
    {
        base.Exit();
        PlayerCombat.ToggleRedZone(false);
    }

    protected override void OnAttack()
    {
        _isRedZoneActive = !_isRedZoneActive;
        PlayerCombat.ToggleRedZone(_isRedZoneActive);
        
        HUDController.Instance.UpdateStateText(_isRedZoneActive 
            ? "Red Zone State - Zone Active - Press Attack to Toggle" 
            : "Red Zone State - Zone Inactive - Press Attack to Toggle");
    }

    protected override void UpdateHUDState()
    {
        HUDController.Instance.UpdateStateText("Red Zone State - Press Attack to Toggle Zone");
    }
}
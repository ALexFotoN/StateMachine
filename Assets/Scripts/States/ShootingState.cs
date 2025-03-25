using UnityEngine;

public class ShootingState : PlayerState
{
    public ShootingState(IInputService inputService, PlayerCombat playerCombat) 
        : base(inputService, playerCombat)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerCombat.ToggleRedZone(false);
        PlayerCombat.SetTransparency(1f);
        PlayerCombat.SetColor(Color.white);
    }

    protected override void OnAttack()
    {
        PlayerCombat.FireBullet();
    }

    protected override void UpdateHUDState()
    {
        HUDController.Instance.UpdateStateText("Shooting State - Press Attack to Fire Bullet");
    }
}
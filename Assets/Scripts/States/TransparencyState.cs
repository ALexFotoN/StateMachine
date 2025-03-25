using UnityEngine;

public class TransparencyState : PlayerState
{
    private bool _isTransparent;
    private const float TransparentAlpha = 0.5f;
    private const float OpaqueAlpha = 1.0f;

    public TransparencyState(IInputService inputService, PlayerCombat playerCombat) 
        : base(inputService, playerCombat)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _isTransparent = false;
        PlayerCombat.SetTransparency(OpaqueAlpha);
        PlayerCombat.ToggleRedZone(false);
        PlayerCombat.SetColor(Color.white);
    }

    protected override void OnAttack()
    {
        _isTransparent = !_isTransparent;
        PlayerCombat.SetTransparency(_isTransparent ? TransparentAlpha : OpaqueAlpha);
        
        HUDController.Instance.UpdateStateText(_isTransparent 
            ? "Transparency State - Player Transparent - Press Attack to Toggle" 
            : "Transparency State - Player Opaque - Press Attack to Toggle");
    }

    protected override void UpdateHUDState()
    {
        HUDController.Instance.UpdateStateText("Transparency State - Press Attack to Toggle Transparency");
    }
}
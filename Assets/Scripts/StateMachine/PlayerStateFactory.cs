public class PlayerStateFactory
{
    private readonly IInputService _inputService;
    private readonly PlayerCombat _playerCombat;

    public PlayerStateFactory(IInputService inputService, PlayerCombat playerCombat)
    {
        _inputService = inputService;
        _playerCombat = playerCombat;
    }

    public ShootingState CreateShootingState()
    {
        return new ShootingState(_inputService, _playerCombat);
    }

    public RedZoneState CreateRedZoneState()
    {
        return new RedZoneState(_inputService, _playerCombat);
    }

    public TransparencyState CreateTransparencyState()
    {
        return new TransparencyState(_inputService, _playerCombat);
    }
    
    public FinalPlayerState CreateFinalState()
    {
        return new FinalPlayerState(_inputService, _playerCombat);
    }
}
public class GameStateFactory
{
    private readonly Bootstrapper _bootstrapper;
    private readonly IInputService _inputService;
    private readonly PlayerMovement _playerMovement;
    private readonly PlayerStateMachine _playerStateMachine;

    public GameStateFactory(Bootstrapper bootstrapper, IInputService inputService, 
        PlayerMovement playerMovement, PlayerStateMachine playerStateMachine)
    {
        _bootstrapper = bootstrapper;
        _inputService = inputService;
        _playerMovement = playerMovement;
        _playerStateMachine = playerStateMachine;
    }

    public GameState CreateGameState()
    {
        return new GameState(_bootstrapper, _inputService, _playerMovement);
    }

    public PauseState CreatePauseState()
    {
        return new PauseState(_bootstrapper, _inputService);
    }

    public FinalState CreateFinalState()
    {
        return new FinalState(_bootstrapper, _playerStateMachine, _playerMovement);
    }
}
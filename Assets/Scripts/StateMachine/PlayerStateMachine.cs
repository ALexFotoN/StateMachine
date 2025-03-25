using System.Collections.Generic;

public class PlayerStateMachine
{
    private IState _currentState;
    private readonly Dictionary<System.Type, IState> _availableStates = new();
    private readonly IInputService _inputService;

    public PlayerStateMachine(IInputService inputService, PlayerStateFactory stateFactory)
    {
        _inputService = inputService;
        
        RegisterState(stateFactory.CreateShootingState());
        RegisterState(stateFactory.CreateRedZoneState());
        RegisterState(stateFactory.CreateTransparencyState());
        RegisterState(stateFactory.CreateFinalState());
        
        SetState<ShootingState>();
    }

    public void Update()
    {
        if (_currentState == null) return;
        _currentState.Update();
        
        if (_inputService.IsStateChangeButtonDown)
        {
            CycleState();
        }
    }

    public void SetState<TState>() where TState : IState
    {
        var type = typeof(TState);

        if (!_availableStates.ContainsKey(type)) return;
        _currentState?.Exit();

        _currentState = _availableStates[type];
        _currentState.Enter();
    }
    
    public void SetState(IState newState)
    {
        _currentState?.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    private void RegisterState(IState state)
    {
        var type = state.GetType();

        _availableStates.TryAdd(type, state);
    }
    
    private void CycleState()
    {
        switch (_currentState)
        {
            case ShootingState:
                SetState<RedZoneState>();
                break;
            case RedZoneState:
                SetState<TransparencyState>();
                break;
            case TransparencyState:
                SetState<ShootingState>();
                break;
        }
    }
}
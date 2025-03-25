using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private IState _currentState;
    private readonly Dictionary<System.Type, IState> _availableStates = new();

    public static GameStateMachine Instance { get; private set; }

    public GameStateMachine(GameStateFactory stateFactory)
    {
        Instance = this;
        
        RegisterState(stateFactory.CreateGameState());
        RegisterState(stateFactory.CreatePauseState());
        RegisterState(stateFactory.CreateFinalState());
    }

    public void Update()
    {
        _currentState?.Update();
    }

    public void SetState<TState>() where TState : IState
    {
        var type = typeof(TState);
        
        if (_availableStates.TryGetValue(type, out var state))
        {
            _currentState?.Exit();

            _currentState = state;
            _currentState.Enter();
        }
        else
        {
            Debug.LogError($"State {type.Name} not found in available states!");
        }
    }

    private void RegisterState(IState state)
    {
        var type = state.GetType();

        _availableStates.TryAdd(type, state);
    }
}
using UnityEngine;
using UnityEngine.Serialization;

public class Bootstrapper : MonoBehaviour
{
    [FormerlySerializedAs("_playerMovement")] [SerializeField] private PlayerMovement playerMovement;
    [FormerlySerializedAs("_playerInput")] [SerializeField] private PlayerInput playerInput;
    [FormerlySerializedAs("_playerCombat")] [SerializeField] private PlayerCombat playerCombat;

    private PlayerStateMachine _playerStateMachine;
    private GameStateMachine _gameStateMachine;
    private PlayerStateFactory _playerStateFactory;
    private GameStateFactory _gameStateFactory;

    private void Start()
    {
        InitializeComponents();
        InitializeStateMachines();
        
        _gameStateMachine.SetState<GameState>();
    }

    private void Update()
    {
        _gameStateMachine.Update();
    }

    private void InitializeComponents()
    {
        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
        
        if (playerInput == null)
        {
            playerInput = FindObjectOfType<PlayerInput>();
        }
        
        if (playerCombat == null)
        {
            playerCombat = FindObjectOfType<PlayerCombat>();
        }
        
        playerMovement.Construct(playerInput);
    }

    private void InitializeStateMachines()
    {
        _playerStateFactory = new PlayerStateFactory(playerInput, playerCombat);

        _playerStateMachine = new PlayerStateMachine(playerInput, _playerStateFactory);

        _gameStateFactory = new GameStateFactory(this, playerInput, playerMovement, _playerStateMachine);
        
        _gameStateMachine = new GameStateMachine(_gameStateFactory);
    }
    
    public PlayerStateMachine GetPlayerStateMachine()
    {
        return _playerStateMachine;
    }
}
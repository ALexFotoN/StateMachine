using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour, IInputService
{
    [FormerlySerializedAs("_horizontalAxisName")] [SerializeField] private string horizontalAxisName = "Horizontal";
    [FormerlySerializedAs("_verticalAxisName")] [SerializeField] private string verticalAxisName = "Vertical";
    [FormerlySerializedAs("_attackButton")] [SerializeField] private KeyCode attackButton = KeyCode.Mouse0;
    [FormerlySerializedAs("_stateChangeButton")] [SerializeField] private KeyCode stateChangeButton = KeyCode.Return;
    [FormerlySerializedAs("_pauseButton")] [SerializeField] private KeyCode pauseButton = KeyCode.Space;
    [FormerlySerializedAs("_exitButton")] [SerializeField] private KeyCode exitButton = KeyCode.Escape;

    private bool _inputEnabled = true;

    public Vector2 MovementAxis => _inputEnabled ? new Vector2(Input.GetAxis(horizontalAxisName), Input.GetAxis(verticalAxisName)) : Vector2.zero;
    public bool IsAttackButtonDown => _inputEnabled && Input.GetKeyDown(attackButton);
    public bool IsStateChangeButtonDown => _inputEnabled && Input.GetKeyDown(stateChangeButton);
    public bool IsPauseButtonDown => Input.GetKeyDown(pauseButton);
    public bool IsExitButtonDown => Input.GetKeyDown(exitButton);

    public void EnableInput()
    {
        _inputEnabled = true;
    }

    public void DisableInput()
    {
        _inputEnabled = false;
    }
}
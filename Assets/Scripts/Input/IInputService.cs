using UnityEngine;

public interface IInputService
{
    Vector2 MovementAxis { get; }
    bool IsAttackButtonDown { get; }
    bool IsStateChangeButtonDown { get; }
    bool IsPauseButtonDown { get; }
    bool IsExitButtonDown { get; }
}
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("_moveSpeed")] [SerializeField] private float moveSpeed = 5f;
    
    private IInputService _inputService;
    private Rigidbody2D _rigidbody;
    private bool _canMove = true;

    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_rigidbody != null) return;
        _rigidbody = gameObject.AddComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
        _rigidbody.freezeRotation = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        if (_canMove && _inputService != null)
        {
            Move();
        }
    }

    private void Move()
    {
        var movement = _inputService.MovementAxis;
        _rigidbody.linearVelocity = movement * moveSpeed;

        if (movement == Vector2.zero) return;
        var angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void EnableMovement()
    {
        _canMove = true;
    }

    public void DisableMovement()
    {
        _canMove = false;
        if (_rigidbody)
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}
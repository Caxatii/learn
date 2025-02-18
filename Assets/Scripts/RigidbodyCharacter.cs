using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyCharacter : MonoBehaviour, IMover
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private GroundDetector _groundDetector;

    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _collider;

    private bool IsGrounded =>
        _groundDetector == null ? true : _groundDetector.GetGrounded();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    public bool TryJump()
    {
        bool isGrounded = IsGrounded;
        if(isGrounded) 
            _rigidbody.velocity += Vector2.up * _jumpForce;

        return isGrounded;
    }

    public void Move(float force)
    {
        _rigidbody.velocity = new Vector2(force * _speed, _rigidbody.velocity.y);
    }
}
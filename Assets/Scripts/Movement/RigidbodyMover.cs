using UnityEngine;

namespace Mono.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class RigidbodyMover : MonoBehaviour, IPhysicMover
    {
        [SerializeField] private float _speed;

        private bool _isGrounded;
        private float _gravityScale;

        private Rigidbody2D _rigidbody;

        private IMover _groundedMover;
        private IMover _flyingMover;
        private IMover _currentMovement;

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            SwitchMover(_isGrounded ? _groundedMover : _flyingMover);
        }

        public void SetIsGrounded(bool value)
        {
            _isGrounded = value;
        }

        public void Move(float direction)
        {
            _rigidbody.gravityScale = direction == 0 && _isGrounded ? 0 : _gravityScale;
            _currentMovement.Move(direction * _speed);
        }

        private void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _gravityScale = _rigidbody.gravityScale;

            _groundedMover = new GroundedMovementState(_rigidbody);
            _flyingMover = new FlyingMovementState(_rigidbody);
            _currentMovement = _flyingMover;
        }

        private void SwitchMover(IMover mover)
        {
            if(mover != _currentMovement)
                _currentMovement = mover;
        }
    }
}
using Mono.Detectors;
using UnityEngine;

namespace Mono.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(GroundDetector))]
    public class RigidbodyJumper : MonoBehaviour, IJumper
    {
        [SerializeField] private float _jumpForce;

        private GroundDetector _groundDetector;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        public bool TryJump()
        {
            if (_groundDetector.IsGrounded) 
                _rigidbody.velocity = Vector2.up * _jumpForce;

            return _groundDetector.IsGrounded;
        }
    }
}
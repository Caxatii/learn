using Mono.Detectors;
using UnityEngine;

namespace Mono.Movement
{
    [RequireComponent(typeof(GroundDetector), typeof(Rigidbody2D))]
    public class GravitySwitcher : MonoBehaviour
    {
        private float _gravity;
        
        private GroundDetector _groundDetector;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _groundDetector = GetComponent<GroundDetector>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _gravity = _rigidbody.gravityScale;
        }

        private void Update()
        {
            _rigidbody.gravityScale = _groundDetector.IsGrounded ? 0 : _gravity;
        }
    }
}
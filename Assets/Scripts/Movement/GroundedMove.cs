using System;
using Mono.Detectors;
using UnityEngine;

namespace Mono.Movement
{
    [RequireComponent(typeof(GroundDetector), typeof(RigidbodyMover))]
    public class GroundedMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private RigidbodyMover _mover;
        private GroundDetector _groundDetector;

        private void Awake()
        {
            _mover = GetComponent<RigidbodyMover>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        public void Move(float direction)
        {
            _mover.AddVelocity(Slide(Vector2.right * direction) * _speed);
        }

        private Vector2 Slide(Vector2 direction)
        {
            Vector2 normal = _groundDetector.ContactNormal;
            return direction - Vector2.Dot(direction, normal) * normal;
        }
    }
}
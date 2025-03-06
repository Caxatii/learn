using Mono.Movement;
using UnityEngine;

namespace Mono.Interactions
{
    [RequireComponent(typeof(RigidbodyMover), typeof(Health))]
    public class DamageImpulse : MonoBehaviour
    {
        [SerializeField] private Vector2 _impulseMultiplier;
        
        private RigidbodyMover _mover;

        private void Awake()
        {
            _mover = GetComponent<RigidbodyMover>();
        }

        public void Push(Vector2 direction)
        {
            _mover.AddVelocity(direction * _impulseMultiplier);
        }
    }
}
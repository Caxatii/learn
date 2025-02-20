using System;
using UnityEngine;

namespace Mono.Detectors
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundDetector : MonoBehaviour, IGroundDetector
    {
        [SerializeField, Range(0, 1)] private float _maxSlope;

        private int _contactsCount;
        public event Action<bool> Changed;

        public bool IsGrounded { get; private set; }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (_contactsCount == collision.contactCount)
                return;

            IsGrounded = GetGrounded(collision);
            _contactsCount = collision.contactCount;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _contactsCount = 0;
            IsGrounded = false;
            Changed?.Invoke(IsGrounded);
        }

        private bool GetGrounded(Collision2D collision)
        {
            bool isGrounded = false;

            foreach (ContactPoint2D contact in collision.contacts)
                if (contact.normal.y >= _maxSlope)
                    isGrounded = true;

            if (IsGrounded != isGrounded)
                Changed?.Invoke(isGrounded);

            return isGrounded;
        }
    }
}
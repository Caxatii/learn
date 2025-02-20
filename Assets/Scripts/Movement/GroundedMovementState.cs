using UnityEngine;

namespace Mono.Movement
{
    public class GroundedMovementState : IMover
    {
        private readonly Rigidbody2D _rigidbody;

        public GroundedMovementState(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(float direction)
        {
            Vector2 vector = Vector2.right * direction;
            Vector2 slideDirection = Slide(vector);
            _rigidbody.velocity = slideDirection;
        }

        private Vector2 Slide(Vector2 direction)
        {
            Vector2 normal = Physics2D.Raycast(_rigidbody.position, Vector2.down).normal;
            return direction - Vector2.Dot(direction, normal) * normal;
        }
    }
}

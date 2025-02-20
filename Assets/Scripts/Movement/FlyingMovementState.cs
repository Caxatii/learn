using UnityEngine;

namespace Mono.Movement
{
    public class FlyingMovementState : IMover
    {
        private readonly Rigidbody2D _rigidbody;

        public FlyingMovementState(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(float direction)
        {
            _rigidbody.velocity = new Vector2(direction, _rigidbody.velocity.y);
        }
    }
}
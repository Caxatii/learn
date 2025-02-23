using UnityEngine;

namespace Mono.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyMover : MonoBehaviour
    {
        private Vector2 _velocity;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void AddVelocity(float x = 0, float y = 0)
        {
            _velocity.x += x;
            _velocity.y += y;
        }

        public void AddVelocity(Vector2 velocity)
        {
            _velocity += velocity;
        }

        private void FixedUpdate()
        {
            if(_velocity.y != 0)
                _rigidbody.MovePosition(_rigidbody.position + _velocity * Time.fixedDeltaTime);
            else
                _rigidbody.velocity = new Vector2(_velocity.x, _rigidbody.velocity.y);

            _velocity *= 0;
        }
    }
}
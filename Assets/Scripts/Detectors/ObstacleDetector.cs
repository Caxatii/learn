using UnityEngine;

namespace Mono.Detectors
{
    [RequireComponent(typeof(Collider2D))]
    public class ObstacleDetector : MonoBehaviour
    {
        private readonly Vector2 _up = Vector2.up;
        private readonly Vector2 _down = Vector2.down;
        
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public bool HasObstacleVertical(bool isUp, float distance)
        {
            var offset = _collider.bounds.center;
            var direction = isUp ? _up : _down;
            offset.y += direction.y * _collider.bounds.extents.y;
            
            return HasObstacle(offset, direction, distance);
        }
        
        private bool HasObstacle(Vector3 startPoint, Vector2 direction, float distance)
        {
            return Physics2D.Raycast(startPoint, direction, distance);
        }
    }
}
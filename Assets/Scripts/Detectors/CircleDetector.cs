using UnityEngine;

namespace Mono.Detectors
{
    public class CircleDetector
    {
        private readonly float _searchRadius;
        private readonly Collider2D[] _collisions = new Collider2D[10];

        public CircleDetector(float searchRadius)
        {
            _searchRadius = searchRadius;
        }

        public bool TryGet<T>(Vector2 castPoint, out T result)
        {
            result = default;

            if (Physics2D.OverlapCircleNonAlloc(castPoint, _searchRadius, _collisions) > 1)
                foreach (var collider in _collisions)
                    if (collider && collider.TryGetComponent<T>(out result))
                        return true;

            return false;
        }
    }
}
using UnityEngine;

namespace Mono.AIBehaviour
{
    public interface IBehaviour
    {
        public void SetTarget(Transform target);
        public Vector2 GetDirection(Vector3 position);
    }
}
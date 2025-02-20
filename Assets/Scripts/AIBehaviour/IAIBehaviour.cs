using UnityEngine;

namespace Mono.AIBehaviour
{
    public interface IAIBehaviour
    {
        public void SetTarget(Transform target);
        public Vector2 GetDirection(Vector3 position);
    }
}
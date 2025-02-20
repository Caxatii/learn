using JetBrains.Annotations;
using UnityEngine;

namespace Mono.AIBehaviour
{
    public class Haunting : IAIBehaviour
    {
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public Vector2 GetDirection(Vector3 position)
        {
            if(_target == null )
                return Vector2.zero;
            
            return (_target.position - position).normalized;
        }
    }
}
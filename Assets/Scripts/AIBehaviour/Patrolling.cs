using UnityEngine;

namespace Mono.AIBehaviour
{
    public class Patrolling : IBehaviour
    {
        private Vector3 _patrolPoint;

        public Patrolling(Vector3 patrolPoint)
        {
            _patrolPoint = patrolPoint;
        }
        
        public void SetTarget(Transform target)
        {
            _patrolPoint = target.position;
        }

        public Vector2 GetDirection(Vector3 position)
        {
            return (_patrolPoint - position).normalized;
        }
    }
}
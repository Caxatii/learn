using System.Collections;
using Mono.Detectors;
using UnityEngine;

namespace Mono.Movement
{
    [RequireComponent(typeof(RigidbodyMover), typeof(ObstacleDetector))]
    public class RigidbodyJumper : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _jumpMultiplier;
        [SerializeField] private float _minDistanceAbove;
        
        private RigidbodyMover _mover;
        private ObstacleDetector _obstacleDetector;
        
        private void Awake()
        {
            _mover = GetComponent<RigidbodyMover>();
            _obstacleDetector = GetComponent<ObstacleDetector>();
        }
        
        public void Jump()
        {
            StartCoroutine(JumpCoroutine());
        }
        
        private IEnumerator JumpCoroutine()
        {
            var delay = new WaitForFixedUpdate();
            float maxTime = _curve.keys[_curve.length - 1].time;
            float time = 0;
            
            while (time < maxTime && _obstacleDetector.HasObstacleVertical(true, _minDistanceAbove) == false)
            {
                _mover.AddVelocity(y: _curve.Evaluate(time) * _jumpMultiplier);
                time += Time.fixedDeltaTime;
                yield return delay;
            }
        }
    }
}
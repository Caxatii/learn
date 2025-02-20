using System;
using System.Collections;
using Mono.AIBehaviour;
using Mono.Animations;
using Mono.Detectors;
using Mono.Movement;
using Mono.User;
using UnityEngine;

namespace Mono.Enemies
{
    [RequireComponent(typeof(IPhysicMover))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private bool _alive;
        [SerializeField] private float _searchDelay;
        [SerializeField] private float _searchRadius;

        [SerializeField] private HumanoidAnimator _animator;
        [SerializeField] private ObjectFlipper _flipper;

        private float _horizontal;
        
        private IPhysicMover _mover;
        private IAIBehaviour _hunting;
        private IAIBehaviour _patrolling;
        private IAIBehaviour _currentAIBehaviour;

        private CircleDetector _circleDetector;

        private void Awake()
        {
            _mover = GetComponent<IPhysicMover>();
            _circleDetector = new(_searchRadius);
            _hunting = new Haunting();
            _patrolling = new Patrolling(transform.position);
            _currentAIBehaviour = _patrolling;
            
            StartCoroutine(SearchTarget());
        }

        private void Update()
        {
            _horizontal = _currentAIBehaviour.GetDirection(transform.position).x;
            PlayAnimations();
        }

        private void FixedUpdate()
        {
            _mover.Move(_horizontal);
        }

        private void PlayAnimations()
        {
            float minValue = 0.01f;
            _animator.PlayWalking(_horizontal * _horizontal > minValue);
            
            if (_horizontal != 0)
                _flipper.Flip(_horizontal < 0);
        }
        
        private IEnumerator SearchTarget()
        {
            var delay = new WaitForSeconds(_searchDelay);

            while(_alive)
            {
                if(_circleDetector.TryGet(transform.position, out Player target))
                {
                    _hunting.SetTarget(target.transform);
                    SwitchBehaviour(_hunting);
                }
                else
                {
                    SwitchBehaviour(_patrolling);
                }
                    
                yield return delay;
            }
        }

        private void SwitchBehaviour(IAIBehaviour behaviour)
        {
            if(_currentAIBehaviour == behaviour)
                return;
            
            _currentAIBehaviour = behaviour;
        }
    }
}

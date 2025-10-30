using System;
using System.Collections;
using Mono.AIBehaviour;
using Mono.Animations;
using Mono.Detectors;
using Mono.Interactions;
using Mono.Movement;
using Mono.User;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mono.Enemies
{
    [RequireComponent(typeof(RigidbodyMover))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _searchDelay;
        [SerializeField] private float _searchRadius;

        [SerializeField] private HumanoidAnimator _animator;
        [SerializeField] private ObjectFlipper _flipper;
        
        private bool _isLive;
        private float _direction;
        
        private IBehaviour _current;
        private Patrolling _patrollingAI;
        private Hunting _huntingAI;
        private Coroutine _coroutine;
        
        private CircleDetector _circleDetector;
        private RigidbodyMover _mover;

        private void Awake()
        {
            _circleDetector = new(_searchRadius);
            _mover = GetComponent<RigidbodyMover>();

            _patrollingAI = new(transform.position);
            _huntingAI = new Hunting();
            
            SwitchBehaviour(_patrollingAI);
        }
        
        private void OnEnable()
        {
            _isLive = true;
            _coroutine = StartCoroutine(SearchTarget());
        }

        private void OnDisable()
        {
            _isLive = false;
            StopCoroutine(_coroutine);
        }

        private void Update()
        {
            _direction = _current.GetDirection(transform.position).x;
            UpdateAnimator();
        }

        private void FixedUpdate()
        {
            _mover.AddVelocity(_direction);
        }

        private void UpdateAnimator()
        {
            float minValue = 0.01f;
            _animator.PlayWalking(_direction * _direction > minValue);
            
            if (_direction != 0)
                _flipper.Flip(_direction < 0);
        }
        
        private IEnumerator SearchTarget()
        {
            var delay = new WaitForSeconds(_searchDelay);

            while(_isLive)
            {
                if(_circleDetector.TryGet(transform.position, out Player target))
                {
                    _huntingAI.SetTarget(target.transform);
                    SwitchBehaviour(_huntingAI);
                }
                else
                {
                    SwitchBehaviour(_patrollingAI);
                }
                    
                yield return delay;
            }
        }

        private IEnumerator SomeMethod()
        {
            _isLive = false;
            yield return null;
        }
        
        private void SwitchBehaviour(IBehaviour behaviour)
        {
            if(_current == behaviour)
                return;
            
            _current = behaviour;
        }
    }
}

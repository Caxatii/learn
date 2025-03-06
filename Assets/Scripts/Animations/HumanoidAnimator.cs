using System.Collections;
using Mono.Interactions;
using UnityEngine;

namespace Mono.Animations
{
    [RequireComponent(typeof(Animator))]
    public class HumanoidAnimator : MonoBehaviour
    {
        [SerializeField] private DiedSequence _sequence;
        
        private Animator _animator;
        private bool _isDied;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _sequence?.Add(PlayDie);
        }

        private void OnDied()
        {
            _isDied = true;
        }
        
        public void PlayWalking(bool value)
        {
            _animator.SetBool(HumanoidAnimatorData.Movement.IsWalking, value);
        }

        public void PlayJumping()
        {
            _animator.SetTrigger(HumanoidAnimatorData.Movement.Jumping);
        }
        
        public void PlayGrounded(bool value)
        {
            _animator.SetBool(HumanoidAnimatorData.Movement.IsGrounded, value);
        }

        private IEnumerator PlayDie()
        {
            _animator.SetTrigger(HumanoidAnimatorData.Interactions.Died);

            yield return new WaitWhile(() => _isDied == false);
        }
    }
}
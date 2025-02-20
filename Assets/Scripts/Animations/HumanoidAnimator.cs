using UnityEngine;

namespace Mono.Animations
{
    [RequireComponent(typeof(Animator))]
    public class HumanoidAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
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
    }
}
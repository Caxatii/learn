using UnityEngine;

namespace Mono.Animations
{
    public static class HumanoidAnimatorData
    {
        public static class Movement
        {
            public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
            public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
            public static readonly int Jumping = Animator.StringToHash(nameof(Jumping));
        }
        
        public static class Interactions
        {
            public static readonly int Died = Animator.StringToHash(nameof(Died));
        }
    }
}

using Mono.Animations;
using Mono.Detectors;
using Mono.Movement;
using UnityEngine;

namespace Mono.User
{
    [RequireComponent(typeof(GroundDetector), typeof(GroundedMove), typeof(RigidbodyJumper)), 
     RequireComponent(typeof(UserInputReader))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private HumanoidAnimator _animator;
        [SerializeField] private ObjectFlipper _flipper;
        
        private GroundedMove _mover;
        private UserInputReader _input;
        private RigidbodyJumper _jumper;
        private GroundDetector _groundDetector;

        private void Awake()
        {
            _groundDetector = GetComponent<GroundDetector>();
            _jumper = GetComponent<RigidbodyJumper>();
            _input = GetComponent<UserInputReader>();
            _mover = GetComponent<GroundedMove>();
        }
        
        private void Update()
        {
            UpdateAnimator();
        }
        
        private void FixedUpdate()
        {
            _mover.Move(_input.GetHorizontal());
            Jump();
        }

        private void Jump()
        {
            if (_input.GetIsJump() && _groundDetector.IsGrounded)
            {
                _jumper.Jump();
                _animator.PlayJumping();
            }
        }

        private void UpdateAnimator()
        {
            float horizontal = _input.GetHorizontal();
            
            _animator.PlayWalking(horizontal != 0);
            _animator.PlayGrounded(_groundDetector.IsGrounded);

            if (horizontal != 0)
                _flipper.Flip(horizontal < 0);
        }
    }
}
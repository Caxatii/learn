using Mono.Animations;
using Mono.Detectors;
using Mono.Movement;
using UnityEngine;

namespace Mono.User
{
    [RequireComponent(typeof(IMover), typeof(IJumper), typeof(GroundDetector))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private HumanoidAnimator _animator;
        [SerializeField] private ObjectFlipper _flipper;
    
        private float _horizontal;
        private IPhysicMover _mover;
        private IJumper _jumper;

        private GroundDetector _groundDetector;
        private UserInputReader _userInput = new();

        private void Awake()
        {
            _mover = GetComponent<IPhysicMover>();
            _jumper = GetComponent<IJumper>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        private void OnEnable()
        {
            _groundDetector.Changed += _mover.SetIsGrounded;
            _groundDetector.Changed += PlayGrounded;
        }

        private void OnDisable()
        {
            _groundDetector.Changed -= _mover.SetIsGrounded;
            _groundDetector.Changed -= PlayGrounded;
        }

        private void FixedUpdate()
        {
            _mover.Move(_horizontal);
        }

        private void Update()
        {
            _horizontal = _userInput.Horizontal;

            Jump();
            PlayAnimation();
        }

        private void Jump()
        {
            if (_userInput.IsJumped)
                if (_jumper.TryJump())
                {
                    _mover.SetIsGrounded(false);
                    _animator.PlayJumping();
                }
        }

        private void PlayAnimation()
        {
            _animator.PlayWalking(_horizontal != 0);

            if (_horizontal != 0)
                _flipper.Flip(_horizontal < 0);
        }

        private void PlayGrounded(bool isGrounded)
        {
            _animator.PlayGrounded(isGrounded);
        }
    }
}
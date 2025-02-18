using UnityEngine;

[RequireComponent(typeof(IMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private CharacterAnimator _animator;
    private IMover _mover;

    private UserInput _userInput = new();

    private void Awake()
    {
        _mover = GetComponent<IMover>();
    }

    private void FixedUpdate()
    {
        float horizontal = _userInput.Horizontal;

        _animator.SetWalking(horizontal != 0);
        _mover.Move(horizontal);

        if (horizontal != 0)
            _animator.Flip(horizontal < 0);
    }

    private void Update()
    {
        if (_userInput.IsJumped)
            if (_mover.TryJump())
                _animator.InvokeJumping();
    }
}

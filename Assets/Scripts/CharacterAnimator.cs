using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsGrounded = nameof(IsGrounded);
    private const string Jumping = nameof(Jumping);

    [SerializeField] private Transform _pivot;
    [SerializeField] private GroundDetector _groundDetector;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetWalking(bool value)
    {
        _animator.SetBool(IsWalking, value);
    }

    public void Flip(bool isFlipped)
    {
        float flippedY = -180;
        float rotationY = isFlipped ? flippedY : 0;
        Quaternion newRotation = Quaternion.Euler(0, rotationY, 0);

        _pivot.rotation = newRotation;
    }

    public void InvokeJumping()
    {
        _animator.SetBool(IsGrounded, false);
        StartCoroutine(AwaitGrounded());
    }

    private IEnumerator AwaitGrounded()
    {
        yield return new WaitUntil(() => _groundDetector.GetGrounded() == false);
        yield return new WaitUntil(() => _groundDetector.GetGrounded());
        _animator.SetBool(IsGrounded, true);
    }
}

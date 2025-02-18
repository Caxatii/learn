using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _alive;
    [SerializeField] private float _searchDelay;
    [SerializeField] private float _searchRadius;
    [SerializeField] private CharacterAnimator _animator;

    private IMover _mover;
    private Vector3 _spawnPoint;
    private Transform _target;
    private Collider2D[] _collisions = new Collider2D[10];

    private void Awake()
    {
        _mover = GetComponent<IMover>();
        _spawnPoint = transform.position;
        StartCoroutine(SearchTarget());
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_target == null)
            Move(_spawnPoint);
        else
            Move(_target.position);
    }

    private void Move(Vector3 position)
    {
        Vector3 target = position - transform.position;
        float horizontal = target.normalized.x;
        
        _mover.Move(horizontal);
        _animator.SetWalking(horizontal != 0);

        if (horizontal != 0)
            _animator.Flip(horizontal < 0);
    }

    private IEnumerator SearchTarget()
    {
        var delay = new WaitForSeconds(_searchDelay);

        while(_alive)
        {
            if (TryGetTarget(out Player target))
                _target = target.transform;
            else
                _target = null;

            yield return delay;
        }
    }

    private bool TryGetTarget(out Player target)
    {
        target = default;

        if (Physics2D.OverlapCircleNonAlloc(transform.position, _searchRadius, _collisions) > 1)
            foreach (var collider in _collisions)
                if (collider != null && collider.TryGetComponent<Player>(out target))
                    return true;

        return false;
    }
}
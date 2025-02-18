using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField, Range(0, 0.2f)] private float _bias;
    [SerializeField] private CapsuleCollider2D _collider;

    private float _divider = 2;

    private Vector3 _overlapOffset;
    private Collider2D[] _cashedÑollisions = new Collider2D[2];

    private void Awake()
    {
        _overlapOffset = GetOffset();
    }

    private void OnDrawGizmos()
    {
        _overlapOffset = GetOffset();
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_collider.bounds.center - _overlapOffset, _collider.size.x / 2 - _bias);
    }

    public bool GetGrounded()
    {
        return Physics2D.OverlapCircleNonAlloc(
            _collider.bounds.center - _overlapOffset,
            _collider.size.x / _divider - _bias,
            _cashedÑollisions) > 1;
    }

    private Vector3 GetOffset()
    {
        return new Vector3(0, (_collider.size.y - _collider.size.x) / _divider + 2 * _bias, 0);
    }
}

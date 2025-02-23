using UnityEngine;

namespace Mono.Animations
{
    public class ObjectFlipper : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;

        private readonly Quaternion _original = Quaternion.identity;
        private readonly Quaternion _flipped = Quaternion.Euler(0, -180, 0);
        
        private void Awake()
        {
            if (_pivot == null)
                _pivot = transform;
        }

        public void Flip(bool isFlipped)
        {
            _pivot.rotation = isFlipped ? _flipped : _original;
        }
    }
}
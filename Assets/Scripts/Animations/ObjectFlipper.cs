using UnityEngine;

namespace Mono.Animations
{
    public class ObjectFlipper : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;

        private void Awake()
        {
            if (_pivot == null)
                _pivot = transform;
        }

        public void Flip(bool isFlipped)
        {
            float flippedY = -180;
            float rotationY = isFlipped ? flippedY : 0;
            Quaternion newRotation = Quaternion.Euler(0, rotationY, 0);

            _pivot.rotation = newRotation;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mono.Detectors
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private ContactFilter2D _contactFilter;
        
        private Collider2D _collider;
        private List<ContactPoint2D> _contacts = new();
        
        public bool IsGrounded { get; private set; }
        public Vector2 ContactNormal { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            IsGrounded = _collider.GetContacts(_contactFilter, _contacts) > 0;
            ContactNormal = _contacts.FirstOrDefault().normal;
        }
    }
}
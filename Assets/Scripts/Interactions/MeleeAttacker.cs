using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mono.Interactions
{
    [RequireComponent(typeof(Collider2D))]
    public class MeleeAttacker : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _delay;
        
        private Coroutine _damageCoroutine;
        private Collider2D _collider;
        private List<Effector> _effectors;
        private List<Health> _damageables = new();

        private void Awake()
        {
            _effectors = GetComponents<Effector>().ToList();
            _collider = GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            _damageCoroutine = StartCoroutine(Damage());
        }

        private void OnDisable()
        {
            StopCoroutine(_damageCoroutine);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health damageable))
                _damageables.Add(damageable);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health damageable))
                _damageables.Remove(damageable);
        }

        private IEnumerator Damage()
        {
            WaitForSeconds delay = new WaitForSeconds(_delay);

            while (enabled)
            {
                if(_damageables.Count > 0)
                    for (var i = 0; i < _damageables.Count; i++)
                    {
                        var damageable = _damageables[i];
                        damageable.TakeDamage(_damage, gameObject);

                        foreach (Effector effector in _effectors)
                            effector.ApplyEffect(damageable.gameObject);
                    }

                yield return delay;
            }
        }
    }
}
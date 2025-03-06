using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mono.Interactions
{
    [RequireComponent(typeof(ColorChanger))]
    public class DamageColor : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private Color _color;
        [SerializeField] private Health _health;
        
        private ColorChanger _colorChanger;
        private Coroutine _coroutine;
        
        private void Awake()
        {
            _colorChanger = GetComponent<ColorChanger>();
        }

        private void OnEnable()
        {
            _health.Damaged += OnDamaged;
        }

        private void OnDisable()
        {
            _health.Damaged -= OnDamaged;
        }

        private void OnDamaged(GameObject attacker = null)
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ColorRoutine());
        }

        private IEnumerator ColorRoutine()
        {
            _colorChanger.Change(_color);
            
            yield return new WaitForSeconds(_delay);
            
            _colorChanger.Return();
        }
    }
}
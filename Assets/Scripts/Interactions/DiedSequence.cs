using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mono.Interactions
{
    [RequireComponent((typeof(Health)))]
    public class DiedSequence : MonoBehaviour
    {
        private Health _health;

        private List<Func<IEnumerator>> _sequence = new();
        
        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }

        public void Add(Func<IEnumerator> sequence)
        {
            _sequence.Add(sequence);
        }
        
        private void OnDied()
        {
            StartCoroutine(Deactivate());
        }

        private IEnumerator Deactivate()
        {
            foreach (var routine in _sequence)
            {
                yield return routine.Invoke();
            }
            
            gameObject.SetActive(false);
        }
    }
}
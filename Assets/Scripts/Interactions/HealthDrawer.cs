using System;
using Mono.Interactions;
using Source.Presentation.HealthView;
using UnityEngine;

namespace Mono
{
    [RequireComponent(typeof(Health))]
    public class HealthDrawer : MonoBehaviour
    {
        [SerializeField] private SliderHealthView _sliderHealthView;
        
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
            OnHealthChanged(_health.CurrentHealth);
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float health)
        {
            _sliderHealthView.Render(health, _health.MaxHealth);
        }
    }
}

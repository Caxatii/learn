using System;
using Mono.Environment;
using UnityEngine;

namespace Mono.Interactions
{//coming soon
    public class Health :  MonoBehaviour, IDamageable
    {
        private float _health;
        private float _maxHealth;
        public event Action Died;   
        
        public void TakeDamage(float damage)
        {
            _health -= damage;
            
            if(_health <= 0)
                Died?.Invoke();
        }

        public void Heal(Medicine heal)
        {
            _health += heal.Value;
            
            if(_health > _maxHealth)
                _health = _maxHealth;
        }
    }
}
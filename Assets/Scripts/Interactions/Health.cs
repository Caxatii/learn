using System;
using Mono.Environment;
using UnityEngine;

namespace Mono.Interactions
{
    public class Health :  MonoBehaviour, IDamageable
    {
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        
        public event Action Died;   
        public event Action<GameObject> Damaged;
        
        public void TakeDamage(float damage, GameObject attacker)
        {
            if(damage < 0)
                throw new InvalidOperationException("Damage can't be less than 0");
            
            if(_health == 0)
                return;
            
            _health -= damage;
            Damaged?.Invoke(attacker);
            
            ClampHealth();
            
            if(_health == 0)
                Died?.Invoke();
        }

        public void Heal(Medicine heal)
        {
            if(heal.Value < 0)
                throw new InvalidOperationException("Health can't be less than 0");
            
            _health += heal.Value;
            
            ClampHealth();
        }

        private void ClampHealth()
        {
            _health = Mathf.Clamp(_health, 0, _maxHealth);
        }
    }
}
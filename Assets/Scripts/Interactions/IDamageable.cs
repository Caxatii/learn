using UnityEngine;

namespace Mono.Interactions
{
    public interface IDamageable
    {
        public void TakeDamage(float damage, GameObject attacker);
    }
}


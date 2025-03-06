using UnityEngine;

namespace Mono.Interactions
{
    public class ImpulseEffector : Effector
    {
        [SerializeField] private Vector2 _impulse;
        
        public override void ApplyEffect(GameObject target)
        {
            if(target.TryGetComponent(out DamageImpulse damagable) == false)
                return;
            
            damagable.Push((target.transform.position - transform.position) * _impulse);
        }
    }
}
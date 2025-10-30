using System.Collections;
using Mono.Environment;
using Mono.Interactions;
using UnityEngine;

namespace Mono.User
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private float _actionTime;
        [SerializeField] private float _range;
        [SerializeField] private float _damage;

        [SerializeField] private LayerMask _layerMask;
        
        [SerializeField] private Health _health;
        [SerializeField] private AbilityView _view;

        private bool _isReady = true;
        private Collider2D[] _cash = new Collider2D[10];

        public void Cast()
        {
            if(_isReady == false)
                return;

            StartCoroutine(CooldownCoroutine());
            StartCoroutine(DamageCoroutine());
            
            _view.Show(_actionTime, _cooldown, _range);
        }

        private IEnumerator DamageCoroutine()
        {
            float time = 0;
            
            while (time < _actionTime)
            {
                yield return null;
                time += Time.deltaTime;
                
                Collider2D collider = Physics2D.OverlapCircle(transform.position, _range, _layerMask);
                
                if (collider == null)
                    continue;

                if(collider.TryGetComponent(out Health health) == false)
                    continue;
                        
                float damage = _damage * Time.deltaTime;
                health.TakeDamage(damage, gameObject);
                _health.Heal(new Medicine(damage));
            }
        }

        private IEnumerator CooldownCoroutine()
        {
            _isReady = false;
            yield return new WaitForSeconds(_actionTime + _cooldown);
            _isReady = true;
        }
        
    }
}
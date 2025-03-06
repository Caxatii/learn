using Mono.Interactions;
using UnityEngine;

namespace Mono.Environment.Collectors
{
    public class MedicineCollector : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MedicineView medicine)) 
                _health.Heal(medicine.Collect());
        }
    }
}
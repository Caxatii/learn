using Mono.Interactions;
using UnityEngine;

namespace Mono.Environment.Collectors
{
    public class MedicineCollector : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            TryGetComponent(out _health);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MedicineView medicine)) 
                _health?.Heal(medicine.Collect());
        }
    }
}
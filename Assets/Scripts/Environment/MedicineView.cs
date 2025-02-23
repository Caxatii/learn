using System;
using UnityEngine;

namespace Mono.Environment
{
    public class MedicineView : Collectable
    {
        [SerializeField] private Medicine _medicine;
        
        public override event Action<Collectable> Collected; 
        
        public void Initialize(Medicine medicine)
        {
            _medicine ??= medicine;
        }
        
        public Medicine Collect()
        {
            Collected?.Invoke(this);
            return _medicine;
        }
    }
}
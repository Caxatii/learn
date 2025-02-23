using System;
using UnityEngine;

namespace Mono.Environment
{
    [Serializable]
    public class Medicine
    {
        [SerializeField] private float _value;
        
        public Medicine(float value)
        {
            _value = value;
        }
        
        public float Value =>
            _value;
    }
}
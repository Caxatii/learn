using System;
using UnityEngine;

namespace Mono.Environment
{
    [Serializable]
    public class Coin
    {
        [SerializeField] private int _value;
        
        public Coin(int value)
        {
            _value = value;
        }

        public int Value => 
            _value;
    }
}

using System;
using UnityEngine;

namespace Mono.Environment
{
    public class CoinView : Collectable
    {
        [SerializeField] private Coin _coin;
        
        public override event Action<Collectable> Collected;

        public Coin Collect()
        {
            Collected?.Invoke(this);
            return _coin;
        }

    }
}
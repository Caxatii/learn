using System;
using UnityEngine;

namespace Mono.Environment
{
    [Serializable]
    public class Wallet
    {
        [SerializeField] private int _coinValue;

        public Wallet(int coinValue)
        {
            _coinValue = coinValue;
        }

        public void Add(Coin coin)
        {
            _coinValue += coin.Value;
        }
    }
}
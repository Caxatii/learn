using UnityEngine;

namespace Mono.Environment
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;

        public void Add(Coin coin)
        {
            _wallet.Add(coin);
        }
    }
}
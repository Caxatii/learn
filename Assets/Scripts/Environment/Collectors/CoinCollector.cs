using UnityEngine;

namespace Mono.Environment.Collectors
{
    [RequireComponent (typeof(Collider2D))]
    public class CoinCollector : MonoBehaviour
    {
        private WalletView _wallet;

        private void Awake()
        {
            TryGetComponent(out _wallet);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out CoinView coinView))
                _wallet?.Add(coinView.Collect());
        }
    }
}
using UnityEngine;

namespace Mono.Environment
{
    [RequireComponent (typeof(Collider2D))]
    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private int _value;

        private void Add(Coin coin)
        {
            _value += coin.Value;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out CoinView coinView) == false) 
                return;
            
            Add(coinView.Coin);
            Destroy(coinView.gameObject);
        }
    }
}
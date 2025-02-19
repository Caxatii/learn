using UnityEngine;

public class CoinView : MonoBehaviour
{
    private Coin _coin;

    public void Initialize(Coin coin)
    {
        if (_coin == null)
            _coin = coin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinCollector collector))
        {
            collector.Add(_coin);
            Destroy(gameObject);
        }
    }
}
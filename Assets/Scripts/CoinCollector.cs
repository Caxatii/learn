using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int _value;

    public void Add(Coin coin)
    {
        _value += coin.Value;
    }
}
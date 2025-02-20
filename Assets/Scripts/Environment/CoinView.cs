using UnityEngine;

namespace Mono.Environment
{
    public class CoinView : MonoBehaviour
    {
        public Coin Coin {  get; private set; }

        public void Initialize(Coin coin)
        {
            Coin ??= coin;
        }
    }
}
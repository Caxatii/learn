using System.Collections.Generic;
using UnityEngine;

namespace Mono.Environment
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private bool _isRandom;
        [SerializeField] private int _minCount;

        [SerializeField] private CoinView _prefab;
        [SerializeField] private List<Transform> _points;

        private void Awake()
        {
            if (_minCount > _points.Count)
                _minCount = _points.Count;

            if (_isRandom)
                SpawnRandom();
            else
                Spawn();
        }

        private void Spawn()
        {
            foreach (var point in _points)
            {
                Instantiate(_prefab, point.position, Quaternion.identity).Initialize(new Coin(1));
            }
        }

        private void SpawnRandom()
        {
            _points.Shuffle();
            int count = Random.Range(_minCount, _points.Count);

            for(int i = 0; i < count; i++)
            {
                Instantiate(_prefab, _points[i].position, Quaternion.identity).Initialize(new Coin(1));
            }
        }
    }
}
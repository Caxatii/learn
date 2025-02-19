using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private bool _isRandom;
    [SerializeField] private int _minCoins;

    [SerializeField] private CoinView _coinPrefab;
    [SerializeField] private List<Transform> _points;

    private void Awake()
    {
        if (_minCoins > _points.Count)
            _minCoins = _points.Count;

        if (_isRandom)
            RandomSpawn();
        else
            Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            Instantiate(_coinPrefab, _points[i].position, Quaternion.identity).Initialize(new Coin(1));
        }
    }

    private void RandomSpawn()
    {
        _points.Shuffle();
        int count = Random.Range(_minCoins, _points.Count);

        for(int i = 0; i < count; i++)
        {
            Instantiate(_coinPrefab, _points[i].position, Quaternion.identity).Initialize(new Coin(1));
        }
    }
}
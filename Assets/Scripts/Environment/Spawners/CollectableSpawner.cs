using System.Collections.Generic;
using UnityEngine;

namespace Mono.Environment.Spawners
{
    public class CollectableSpawner : MonoBehaviour
    {
        [SerializeField] private bool _isRandom;
        [SerializeField] private int _minCount;

        [SerializeField] private Collectable _prefab;
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
                Create(point.position);
        }

        private void OnDestroyPrefab(Collectable prefab)
        {
            prefab.Collected -= OnDestroyPrefab;
            Destroy(prefab.gameObject);
        }

        private void SpawnRandom()
        {
            _points.Shuffle();
            int count = Random.Range(_minCount, _points.Count);

            for(int i = 0; i < count; i++) 
                Create(_points[i].position);
        }

        private void Create(Vector3 position)
        {
            Instantiate(_prefab, position, Quaternion.identity).Collected += OnDestroyPrefab;
        }
    }
}
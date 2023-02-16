using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services
{
    public class SpawnService : MonoBehaviour
    {
        [SerializeField] private CoinService _coinService;
        
        [SerializeField] private Transform _creationZone;

        [SerializeField] private CoinView _coinPrefab;
        [SerializeField] private int _coinsCount;

        private const float BorderLimit = 0.5f;
        
        private void Awake()
        {
            var coinsList = new List<CoinView>();

            for (var i = 0; i < _coinsCount; i++)
            {
                var position = GetRandomPosition();
                var coin = Instantiate(_coinPrefab, position, Quaternion.identity, transform);
                coinsList.Add(coin);
            }
            
            _coinService.Init(coinsList);
        }

        private Vector3 GetRandomPosition()
        {
            var x = Random.Range(-BorderLimit, BorderLimit);
            var z = Random.Range(-BorderLimit, BorderLimit);

            return _creationZone.TransformPoint(x, 0, z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_creationZone.position, _creationZone.localScale);
            Gizmos.color = Color.white;
        }
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Services
{
    public class CoinService : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _coinsCount;
        private int _collectedCoinsCount;
        private List<CoinView> _coins;

        public void Init(List<CoinView> coins)
        {
            gameObject.SetActive(false);
            
            _coins = coins;
            _coinsCount = _coins.Count;

            ChangeScoreText();
            
            gameObject.SetActive(true);
        }
        
        [CanBeNull]
        public CoinView GetClosest(Vector3 point)
        {
            var minDistance = Mathf.Infinity;
            CoinView closestCoin = null;
            
            foreach (var coin in _coins)
            {
                var distance = Vector3.Distance(coin.transform.position, point);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCoin = coin;
                }
            }

            return closestCoin;
        }

        private void OnCoinDestroy(CoinView coin)
        {
            _collectedCoinsCount++;
            _coins.Remove(coin);

            ChangeScoreText();
        }

        private void ChangeScoreText()
        {
            _scoreText.text = $"Монеты: {_collectedCoinsCount}/{_coinsCount}";
        }

        private void OnEnable()
        {
            foreach (var coin in _coins)
            {
                coin.OnDestroy += OnCoinDestroy;
            }
        }

        private void OnDisable()
        {
            foreach (var coin in _coins)
            {
                coin.OnDestroy -= OnCoinDestroy;
            }
        }
    }
}
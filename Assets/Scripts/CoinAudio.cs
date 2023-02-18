using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinAudio : MonoBehaviour
{
        private AudioSource _collectCoin;

        private void Start()
        {
                _collectCoin = GetComponent<AudioSource>();
        }

        public void PlayCollectCoin()
        {
                _collectCoin.Play();
        }
}
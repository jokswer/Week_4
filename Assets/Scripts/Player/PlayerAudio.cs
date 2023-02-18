using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : MonoBehaviour
    {
        private AudioSource _move;

        private void Start()
        {
            _move = GetComponent<AudioSource>();
        }

        public void PlayMove(float speed)
        {
            _move.pitch = Random.Range(0.7f, 1f);
            _move.volume = Mathf.Lerp(0, speed * 0.5f, Time.deltaTime * 2f);
        }

        public void StopMove()
        {
            _move.volume = 0;
        }
    }
}
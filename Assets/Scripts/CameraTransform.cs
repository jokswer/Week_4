using Player;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private float _lerpRate = 10f;

    private void LateUpdate()
    {
        var sum = _playerView.GetVelocitiesSum();

        transform.position = _playerView.Position;
        transform.rotation =
            Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(sum), Time.deltaTime * _lerpRate);
    }
}
using Player;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [Header("Player Config")] 
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private float _force = 5f;

    private PlayerPresenter _playerPresenter;
    private PlayerModel _playerModel;

    private void Awake()
    {
        _playerModel = new PlayerModel(_force);
        _playerPresenter = new PlayerPresenter(_playerView, _playerModel);
    }

    private void FixedUpdate()
    {
        _playerPresenter.FixedUpdate();
    }

    private void OnEnable()
    {
        _playerPresenter.OnEnable();
    }

    private void OnDisable()
    {
        _playerPresenter.OnDisable();
    }
}
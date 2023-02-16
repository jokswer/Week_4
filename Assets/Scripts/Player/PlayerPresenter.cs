namespace Player
{
    public class PlayerPresenter
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;

        public PlayerPresenter(PlayerView playerView, PlayerModel playerModel)
        {
            _playerView = playerView;
            _playerModel = playerModel;
        }

        public void FixedUpdate()
        {
            _playerView.AddTorque(_playerModel.VerticalForce, _playerModel.HorizontalForce);
        }

        public void OnEnable()
        {
            _playerModel.OnEnable();
        }

        public void OnDisable()
        {
            _playerModel.OnDisable();
        }
    }
}
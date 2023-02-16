namespace Player
{
    public class PlayerModel
    {
        private PlayerInput _playerInput;
        private float _force;

        public float HorizontalForce => _playerInput.Move.x * _force;
        public float VerticalForce => _playerInput.Move.y * _force;

        public PlayerModel(float force)
        {
            _playerInput = new PlayerInput();
            _force = force;
        }

        public void OnEnable()
        {
            _playerInput.Enable();
        }

        public void OnDisable()
        {
            _playerInput.Disable();
        }
    }
}
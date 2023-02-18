using UnityEngine;

namespace Services
{
    public class HeaderService : MonoBehaviour
    {
        [SerializeField] private CoinService _coinService;

        [SerializeField] private GameObject _pointer;
        [SerializeField] private GameObject _crown;

        private PointerView _pointerView;

        private void Start()
        {
            ActivatePointer();
            _pointerView = _pointer.GetComponent<PointerView>();
        }

        private void Update()
        {
            var coin = _coinService.GetClosest(_pointer.transform.position);

            if (coin)
            {
                _pointerView.RotatePointer(coin);
            }

            if (!coin && !_crown.activeInHierarchy)
            {
                ActivateCrown();
            }
        }

        private void ActivateCrown()
        {
            _pointer.SetActive(false);
            _crown.SetActive(true);
        }

        private void ActivatePointer()
        {
            _pointer.SetActive(true);
            _crown.SetActive(false);
        }
    }
}
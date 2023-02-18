using Services;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private CoinService _coinService;
    private CoinView _closestCoin;
    
    void Update()
    {
        _closestCoin = _coinService.GetClosest(transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _closestCoin.transform.position);
    }
}

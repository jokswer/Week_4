using UnityEngine;

public class PointerView : MonoBehaviour
{
    [SerializeField] private float _lerpRate = 5f;

    public void RotatePointer(CoinView coin)
    {
        var target = coin.transform.position - transform.position;
        var targetXZ = new Vector3(target.x, 0, target.z);

        transform.rotation =
            Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetXZ), Time.deltaTime * _lerpRate);
    }
}
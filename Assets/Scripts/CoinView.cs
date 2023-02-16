using System;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    public event Action<CoinView> OnDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        OnDestroy?.Invoke(this);
        Destroy(gameObject);
    }
}

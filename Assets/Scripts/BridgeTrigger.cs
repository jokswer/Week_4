using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] private List<BlockTransform> _blocks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var block in _blocks)
            {
                block.StartTransform();
            }
        }
    }
}
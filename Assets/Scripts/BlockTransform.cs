using System.Collections;
using UnityEngine;

public class BlockTransform : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rate = 1f;

    public void StartTransform()
    {
        StartCoroutine(TransformToTarget());
    }

    private IEnumerator TransformToTarget()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _rate);
            yield return null;
        }
    }
}
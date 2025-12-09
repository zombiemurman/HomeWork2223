using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFlag : MonoBehaviour
{
    private Vector3 _target;

    private float _minDistance = 0.2f;

    private void Update()
    {
        if(Vector3.Distance(_target, transform.position) <= _minDistance)
            Destroy(gameObject);
    }

    public void Initialize(Vector3 target)
    {
        _target = target;
    }
}

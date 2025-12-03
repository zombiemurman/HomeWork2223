using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputFlag : MonoBehaviour
{
    private float _timeToDestroy = 1;

    private void Update()
    {
        _timeToDestroy -= Time.deltaTime;

        if (_timeToDestroy <= 0)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ViewController : MonoBehaviour
{
    [SerializeField] GameObject _mousePointPrefab;
    [SerializeField] private LayerMask _layerMaskFloor;

    private Controller _viewController;

    private void Awake()
    {
        _viewController = new MouseInputController(_mousePointPrefab, _layerMaskFloor);
        _viewController.Enable();
    }

    private void Update()
    {
        _viewController.Update(Time.deltaTime);
    }
}

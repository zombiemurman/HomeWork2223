using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MouseInputController : Controller
{
    GameObject _mousePointPrefab;

    GameObject _mousePoint;

    private LayerMask _layerMaskFloor;

    public MouseInputController(GameObject mousePointPrefab, LayerMask layerMaskFloor)
    {
        _mousePointPrefab = mousePointPrefab;
        _layerMaskFloor = layerMaskFloor;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_mousePoint != null)
                Object.Destroy(_mousePoint);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMaskFloor.value))
            {
                _mousePoint = Object.Instantiate(_mousePointPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}

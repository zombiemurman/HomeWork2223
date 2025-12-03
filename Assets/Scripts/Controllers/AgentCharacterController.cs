using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCharacterController : Controller
{
    private Character _character;

    private LayerMask _layerMask;

    public AgentCharacterController(Character character, LayerMask layerMask)
    {
        _character = character;
        _layerMask = layerMask;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask.value))
            {
                _character.SetDestination(hit.point);
            }
        }
    }
}

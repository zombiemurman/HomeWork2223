using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentCharacterController : Controller
{
    private Character _character;

    private LayerMask _layerMask;

    private NavMeshPath _pathToTarget = new NavMeshPath();

    public AgentCharacterController(Character character, LayerMask layerMask)
    {
        _character = character;
        _layerMask = layerMask;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if(_character.IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
        {
            if(_character.InJumpProcess == false)
            {
                _character.SetRotationDirection(offMeshLinkData.endPos - offMeshLinkData.startPos);

                _character.Jump(offMeshLinkData);
            }

            return;
        }


        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask.value))
            {
                if (_character.TryGetPath(hit.point, _pathToTarget))
                    _character.SetDestination(hit.point);
            }
        }
    }
}

using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AgentBoringController : Controller
{
    private Character _character;

    private float _movementRange;

    private NavMeshPath _pathToTarget = new NavMeshPath();

    private Vector3 _currentTargget;

    public AgentBoringController(Character character, float MovementRange)
    {
        _character = character;
        _movementRange = MovementRange;
    }

    protected override void UpdateLogic(float deltaTime)
    {

        if (_character.IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
        {
            if (_character.InJumpProcess == false)
            {
                _character.SetRotationDirection(offMeshLinkData.endPos - offMeshLinkData.startPos);

                _character.Jump(offMeshLinkData);
            }

            return;
        }

        if (_character.CurrentVelocity.magnitude <= 0.05f)
            _currentTargget = GetTargetPoint();

        if (_character.TryGetPath(_currentTargget, _pathToTarget))
            _character.SetDestination(_currentTargget);

    }

    private Vector3 GetTargetPoint()
    {
        float positionX = Random.Range(_character.Position.x - _movementRange, _character.Position.x + _movementRange);
        float positionZ = Random.Range(_character.Position.z - _movementRange, _character.Position.z + _movementRange);

        return new Vector3(positionX, 0, positionZ);
    }
}

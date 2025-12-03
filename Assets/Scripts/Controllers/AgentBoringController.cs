using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AgentBoringController : Controller
{
    private Character _character;

    private float _timeWithoutAction;

    private float _currentTimeWithoutAction;

    private float _movementRange;

    private NavMeshPath _pathToTarget = new NavMeshPath();

    public AgentBoringController(Character character, float timeWithoutAction, float MovementRange)
    {
        _character = character;
        _timeWithoutAction = timeWithoutAction;
        _movementRange = MovementRange;

        _currentTimeWithoutAction = 0;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if(_character.CurrentVelocity == Vector3.zero)
            _currentTimeWithoutAction += Time.deltaTime;
        else
            _currentTimeWithoutAction = 0;

        if (_currentTimeWithoutAction >= _timeWithoutAction)
        {
            float positionX = Random.Range(_character.Position.x - _movementRange, _character.Position.x + _movementRange);
            float positionZ = Random.Range(_character.Position.z- _movementRange, _character.Position.z + _movementRange);

            Vector3 direction = new Vector3(positionX, 0, positionZ);

            if(_character.TryGetPath(direction, _pathToTarget))
            {
                _character.SetDestination(direction);
            }
        }
    }
}

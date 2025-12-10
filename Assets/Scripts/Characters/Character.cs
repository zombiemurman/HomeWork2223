using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IHealth, IDamageable, IDirectionalAgentMovable, IDirectionalAgentRotatable
{
    private NavMeshAgent _agent;

    private AgentMover _mover;
    private DirectionalRotater _rotator;
    private AgentJumper _jumper;

    private HealthComponent _healthComponent;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _health;

    [SerializeField] private AnimationCurve _jumpCurve;

    [SerializeField] private CharacterView _characterView;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    public Vector3 Position => transform.position;

    public float Health => _healthComponent.Health;

    public bool IsDie => _healthComponent.IsDie;

    public Vector3 CurrentTarget {  get; private set; }

    public bool InJumpProcess => _jumper.InProcess;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _healthComponent = new HealthComponent(_health);

        _mover = new AgentMover(_agent, _moveSpeed);
        _rotator = new DirectionalRotater(transform, _rotationSpeed);

        _jumper = new AgentJumper(_jumpSpeed, _agent, this, _jumpCurve);
    }

    private void Update()
    {
        _rotator.Upadate(Time.deltaTime);
    }

    public void SetDestination(Vector3 position)
    {
        _mover.SetDestination(position);
        CurrentTarget = position;
    }

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetRotationDirection(inputDirection);

    public void StopMove() => _mover.Stop();

    public void ResumeMove()
    {
        if(IsDie)
            return;

        _mover.Resume();
    } 

    public void TakeDamage(float damage)
    {
        _healthComponent.TakeDamage(damage);
        
        Debug.Log(_healthComponent.Health);

        _characterView.TakeDamage();

       if(IsDie)
            StopMove();
    }

    public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
        => NavMeshUtils.TryGetPah(_agent, targetPosition, pathToTarget);

    public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
    {
        if(_agent.isOnOffMeshLink)
        {
            offMeshLinkData = _agent.currentOffMeshLinkData;
            return true;    
        }

        offMeshLinkData = default(OffMeshLinkData);
        return false;
    }

    public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData);
}

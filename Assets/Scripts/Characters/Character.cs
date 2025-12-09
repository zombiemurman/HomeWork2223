using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IHealth, IDamageable, IDirectionalAgentMovable, IDirectionalAgentRotatable
{
    private NavMeshAgent _agent;

    private AgentMover _mover;
    private DirectionalRotater _rotator;

    private HealthComponent _healthComponent;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _health;

    [SerializeField] private CharacterView _characterView;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    public Vector3 Position => transform.position;

    public float Health => _healthComponent.Health;

    public bool IsDie => _healthComponent.IsDie;

    public Vector3 CurrentTarget {  get; private set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _healthComponent = new HealthComponent(_health);

        _mover = new AgentMover(_agent, _moveSpeed);
        _rotator = new DirectionalRotater(transform, _rotationSpeed);
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
}

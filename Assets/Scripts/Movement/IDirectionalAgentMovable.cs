using UnityEngine;

public interface IDirectionalAgentMovable : ITransformPosition
{
    Vector3 CurrentVelocity { get; }

    void SetDestination(Vector3 inputDirection);
}


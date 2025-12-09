using UnityEngine;

public interface IDirectionalAgentMovable
{
    Vector3 CurrentVelocity { get; }

    void SetDestination(Vector3 inputDirection);
}


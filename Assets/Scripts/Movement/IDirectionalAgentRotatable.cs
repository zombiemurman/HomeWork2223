using UnityEngine;

public interface IDirectionalAgentRotatable : ITransformPosition
{
    void SetRotationDirection(Vector3 inputDirection);
}

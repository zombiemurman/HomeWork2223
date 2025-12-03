using UnityEngine;

public class DirectionalRotater
{
    private Transform _transform;

    private float _rotationSpeed;

    private Vector3 _currentDirection;

    public DirectionalRotater(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public Quaternion CurrentRotation => _transform.rotation;

    public void SetRotationDirection(Vector3 direction)
    {
        _currentDirection = direction;
    }

    public void Upadate(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float step = _rotationSpeed * deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}

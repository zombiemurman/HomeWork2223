
using UnityEngine;

public class IdleDetector
{
    private Character _character;

    private float _idleDelay;
    
    private float _idleTimer;

    private bool _isIdle;

    public IdleDetector(Character character, float idleDelay)
    {
        _character = character;
        _idleDelay = idleDelay;
    }

    public bool IsIdle => _isIdle;

    public void Update()
    {
        _idleTimer += Time.deltaTime;

        if (HasInput() || IsMoving())
        {
            _idleTimer = 0;
            _isIdle = false;
            return;
        }

        if (_idleTimer >= _idleDelay)
        {
            _isIdle = true;
        }
    }

    private bool HasInput()
    {
        return Input.GetMouseButtonDown(0);
    }

    private bool IsMoving()
    { 
        return _character.CurrentVelocity.magnitude > 0.05f;
    }
}


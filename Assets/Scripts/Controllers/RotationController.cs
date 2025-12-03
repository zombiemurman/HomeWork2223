using UnityEngine;

public class RotationController : Controller
{

    private IDirectionalAgentRotatable _rotatable;

    private IDirectionalAgentMovable _movable;

    public RotationController(IDirectionalAgentRotatable rotatable, IDirectionalAgentMovable movable) 
    {
        _rotatable = rotatable;
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _rotatable.SetRotationDirection(_movable.CurrentVelocity);
    }
}


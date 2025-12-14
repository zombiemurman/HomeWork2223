using UnityEngine;
using UnityEngine.TextCore.Text;

public class StateController : Controller
{
    private Controller _idleController;

    private Controller _activeController;

    private Character _character;

    public StateController(Controller idleController, Controller activeController, Character character)
    {
        _idleController = idleController;
        _activeController = activeController;

        _character = character;
    }

    public override void Enable()
    {
        base.Enable();
    }

    public override void Disable()
    {
        base.Disable();
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (_character.IsIdle)
        {
            _idleController.Enable();
            _activeController.Disable();

            _idleController.Update(Time.deltaTime);

        }
        else
        {
            _idleController.Disable();
            _activeController.Enable();

            _activeController.Update(Time.deltaTime);
        }
    }
}

using UnityEngine;

public class StateController : Controller
{
    private Controller _idleController;

    private Controller _activeController;

    private Controller _currentController;

    private float _timeWithoutAction;

    private float _currentTime;

    public StateController(Controller idleController, Controller activeController, float timeWithoutAction)
    {
        _idleController = idleController;
        _activeController = activeController;
        
        _timeWithoutAction = timeWithoutAction;
        
        _currentTime = 0;
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
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeWithoutAction)
        {
            _idleController.Enable();
            _activeController.Disable();

            _idleController.Update(Time.deltaTime);
        }
          
        if (Input.GetMouseButtonDown(0))
        {
            _idleController.Disable();
            _activeController.Enable();
            _currentTime = 0;

            _activeController.Update(Time.deltaTime);
        }
    }
}

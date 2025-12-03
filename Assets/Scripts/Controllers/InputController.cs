using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Character _character;

    [SerializeField] private LayerMask _layerMaskFloor;

    private Controller _characterController;

    private void Awake()
    {
        _characterController = new CompositController(
            new AgentCharacterController(_character, _layerMaskFloor),
            new RotationController(_character, _character),
            new AgentBoringController(_character, 2, 4));

        _characterController.Enable();

    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
    }
}

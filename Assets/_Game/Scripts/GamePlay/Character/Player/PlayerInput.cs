using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 direction { get; private set; }
    public event Action OnMove;
    public event Action OnStop;
    void Update()
    {
        GetInteractInput();
        GetMovementInput();
    }

    private void GetMovementInput()
    {
        direction = JoystickControl.direct;
    }

    private void GetInteractInput()
    {
        if (Input.GetMouseButton(0))
        {
            OnMove?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnStop?.Invoke();
        }
    }
}
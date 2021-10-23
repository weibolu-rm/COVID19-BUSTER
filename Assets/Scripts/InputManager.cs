using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[Serializable] public class MoveInputEvent : UnityEvent<Vector2> {};
[Serializable] public class PauseInputEvent : UnityEvent{};
public class InputManager : MonoBehaviour
{
    private Controls _controls;
    public MoveInputEvent moveInputEvent;
    public PauseInputEvent pauseInputEvent;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
        _controls.Gameplay.Move.performed += OnMovePerformed;
        _controls.Gameplay.Move.canceled += OnMovePerformed;
        _controls.Gameplay.Pause.performed += _ => OnPausePerformed();

    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        Vector2 moveInput = ctx.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput);
    }

    private void OnPausePerformed()
    {
        pauseInputEvent.Invoke();
    }




    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}

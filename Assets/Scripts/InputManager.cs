using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[Serializable]
public class MoveInputEvent : UnityEvent<Vector2> {};
public class InputManager : MonoBehaviour
{
    private Controls _controls;
    public MoveInputEvent moveInputEvent;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
        _controls.Gameplay.Move.performed += OnMovePerformed;
        _controls.Gameplay.Move.canceled += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        Vector2 moveInput = ctx.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput);
    }




    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}

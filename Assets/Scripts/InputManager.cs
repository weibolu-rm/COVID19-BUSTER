using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[Serializable] public class MoveInputEvent : UnityEvent<Vector2> {};
[Serializable] public class PauseInputEvent : UnityEvent{};
[Serializable] public class MaskShootInputEvent : UnityEvent{};
[Serializable] public class VaccineShootInputEvent : UnityEvent{};
public class InputManager : MonoBehaviour
{
    private Controls _controls;
    public MoveInputEvent moveInputEvent;
    public PauseInputEvent pauseInputEvent;
    public MaskShootInputEvent MaskShootInputEvent;
    public VaccineShootInputEvent VaccineShootInputEvent;

    
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
        _controls.Gameplay.MaskShoot.performed += _ => OnMaskShootPerformed();
        _controls.Gameplay.VaccineShoot.performed += _ => OnVaccineShootPerformed();

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

    private void OnMaskShootPerformed()
    {
        MaskShootInputEvent.Invoke();
    }
    
    private void OnVaccineShootPerformed()
    {
        VaccineShootInputEvent.Invoke(); 
    }
    
    

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}

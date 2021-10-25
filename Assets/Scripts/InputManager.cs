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
[Serializable] public class IsolationInteractionInputEvent : UnityEvent{};
[Serializable] public class DisinfectInputEvent : UnityEvent{};
public class InputManager : MonoBehaviour
{
    private Controls _controls;
    public MoveInputEvent moveInputEvent;
    public PauseInputEvent pauseInputEvent;
    public MaskShootInputEvent maskShootInputEvent;
    public VaccineShootInputEvent vaccineShootInputEvent;
    public IsolationInteractionInputEvent isolationInteractionInputEvent;
    public DisinfectInputEvent disinfectInputEvent;

    
    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
        _controls.Action.Enable();
        _controls.Gameplay.Move.performed += OnMovePerformed;
        _controls.Gameplay.Move.canceled += OnMovePerformed;
        _controls.Gameplay.Pause.performed += _ => OnPausePerformed();
        _controls.Action.MaskShoot.performed += _ => OnMaskShootPerformed();
        _controls.Action.VaccineShoot.performed += _ => OnVaccineShootPerformed();
        _controls.Action.IsolationInteraction.performed += _ => OnIsolationInteractionPerformed();
        _controls.Action.Disinfect.performed += _ => OnDisinfectPerformed();

    }


    private void OnDisable()
    {
        _controls.Gameplay.Disable();
        _controls.Action.Disable();
    }
    
    // For external use, here only need for "Action" ActionMap
    public void ToggleActionMap()
    {
        if (_controls.Action.enabled)
        {
            _controls.Action.Disable();
        }
        else
        {
            _controls.Action.Enable(); 
        }
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
        maskShootInputEvent.Invoke();
    }
    
    private void OnVaccineShootPerformed()
    {
        vaccineShootInputEvent.Invoke(); 
    }

    private void OnDisinfectPerformed()
    {
        disinfectInputEvent.Invoke();
    }

    private void OnIsolationInteractionPerformed()
    {
        isolationInteractionInputEvent.Invoke();
    }


}

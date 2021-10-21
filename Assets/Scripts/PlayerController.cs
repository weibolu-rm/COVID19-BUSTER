using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;


    private Vector2 _moveInput;
    private Vector2 _velocity;

    private void Update()
    {
        _velocity = _moveInput * player.GetMoveSpeed();

        if (_moveInput.magnitude < 0.1f)
        {
            // State = idle
            _velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        ApplyVelocity(Time.deltaTime);
    }

    private void ApplyVelocity(float delta)
    {
        var rb = player.Rigidbody2D;
        rb.MovePosition(rb.position + _velocity * delta); 
    }
    

    public void OnMoveInput(Vector2 moveInput)
    {
        _moveInput = moveInput;
    }
    
}

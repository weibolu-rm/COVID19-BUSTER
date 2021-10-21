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
        
        ChangeSprites();
    }

    private void ChangeSprites()
    {
        if (_moveInput == Vector2.zero) return;
        
        if (_moveInput.y > 0)
        {
            player.SetSpritesUp();
        }
        else if (_moveInput.y < 0)
        {
            player.SetSpritesDown();
        }
        else if (_moveInput.x > 0)
        {
            player.SetSpritesRight();
        }
        else if (_moveInput.x < 0)
        {
            player.SetSpritesLeft();
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

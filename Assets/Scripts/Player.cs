using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{

    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody2D rb;

    public FloatValue currentMaskCount;
    public FloatValue currentVaccineCount;
    public Rigidbody2D Rigidbody2D => rb;
    
    [Header("EVENTS")]
    public GameEvent playerMaskShootEvent;
    public GameEvent playerMaskReloadEvent;
    public GameEvent playerVaccineShootEvent;
    public GameEvent playerVaccineReloadEvent;

    public PlayerController PlayerController => playerController;


    private void Update()
    {
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        if(mouse.leftButton.wasPressedThisFrame)
            ShootVaccine();
        
        
        if(mouse.rightButton.wasPressedThisFrame)
            ReloadVaccine();
    }

    public void ShootMask()
    {
        if (currentMaskCount.runTimeValue > 0)
        {
            currentMaskCount.runTimeValue -= 1;
            // Shoot mask
            // ...

            playerMaskShootEvent.Raise();
        }
    }

    public void ShootVaccine()
    {
        if (currentVaccineCount.runTimeValue > 0)
        {
            currentVaccineCount.runTimeValue -= 1;
            // Shoot vacc
            // ...

            playerVaccineShootEvent.Raise();
        }
    }
    public void ReloadMasks()
    {
        currentMaskCount.runTimeValue = currentMaskCount.initialValue;
        playerMaskReloadEvent.Raise();
    }

    public void ReloadVaccine()
    {
        currentVaccineCount.runTimeValue = currentVaccineCount.initialValue;
        playerVaccineReloadEvent.Raise();
    }


    
}


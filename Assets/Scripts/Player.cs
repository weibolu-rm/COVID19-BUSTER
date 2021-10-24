using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]
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

    [Header("Projectiles")] 
    public Transform currentForward;
    public Projectile mask;
    public Projectile vaccine;
    public float shootCd = 100f;

    private float _nextShotTime;
    

    public PlayerController PlayerController => playerController;

    private void Start()
    {
        _nextShotTime = Time.time;
    }

    private void Update()
    {
        // FOR DEBUG
        Keyboard kb = InputSystem.GetDevice<Keyboard>();

        if (kb.rKey.wasPressedThisFrame)
        {
            ReloadMasks();
            ReloadVaccine();
        } 

    }

    public void ShootMask()
    {
        if (currentMaskCount.runTimeValue > 0)
        {
            currentMaskCount.runTimeValue -= 1;
            // Shoot mask
            // ...
            Shoot(mask);

            playerMaskShootEvent.Raise();
        }
    }

    public void ShootVaccine()
    {
        if (currentVaccineCount.runTimeValue > 0 && Time.time > _nextShotTime)
        {
            currentVaccineCount.runTimeValue -= 1;
            // Shoot vacc
            // ...

            Shoot(vaccine);
            playerVaccineShootEvent.Raise();
        }
    }

    private void Shoot(Projectile projectile)
    {
        _nextShotTime = Time.time + shootCd/1000;
        float angle = Mathf.Atan2(Forward.y, Forward.x) * Mathf.Rad2Deg;
        Projectile pew = Instantiate(projectile, rb.position, Quaternion.Euler(0f, 0f, angle)) as Projectile;
    }
    private void ReloadMasks()
    {
        currentMaskCount.runTimeValue = currentMaskCount.initialValue;
        playerMaskReloadEvent.Raise();
    }

    private void ReloadVaccine()
    {
        currentVaccineCount.runTimeValue = currentVaccineCount.initialValue;
        playerVaccineReloadEvent.Raise();
    }


    
}


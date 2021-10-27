using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
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
    public Projectile mask;
    public Projectile vaccine;
    public float shootCd = 100f;

    [Header("Player specific sprite")] 
    [SerializeField] private SpriteRenderer screamBubble;
    [SerializeField] private float bubbleTimeLength;
    [SerializeField] private ScreamInteraction _screamInteraction;
    

    public float bubbleCd = 10000f;
    public bool canScream = true;
    
    private float _nextShotTime;
    private float _nextBubbleTime;
    private float _lastBubbleTime;
    

    public PlayerController PlayerController => playerController;

    protected override void Start()
    {
        base.Start();
        _nextShotTime = Time.time;
        _lastBubbleTime = Time.time;
        _nextBubbleTime = Time.time;
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

        UpdateScreamBubble();
    }

    private void UpdateScreamBubble()
    {
        
        // reset scream
        if (Time.time > _nextBubbleTime)
        {
            canScream = true;
        }
        
        if (Time.time > _lastBubbleTime + bubbleTimeLength)
        {
            screamBubble.gameObject.SetActive(false);
        }
    }
    private void Shoot(Projectile projectile)
    {
        _nextShotTime = Time.time + shootCd/1000;
        float angle = Mathf.Atan2(Forward.y, Forward.x) * Mathf.Rad2Deg;
        Projectile pew = Instantiate(projectile, rb.position, Quaternion.Euler(0f, 0f, angle)) as Projectile;
        pew.Initialize(Forward);
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

    public void ReloadItem(FloatValue itemCounter)
    {
        if (itemCounter == currentVaccineCount)
        {
            ReloadVaccine();
        }
        else if (itemCounter == currentMaskCount)
        {
            ReloadMasks();
        }
    }
    
    public void OnShootMaskInput()
    {
        if (currentMaskCount.runTimeValue > 0)
        {
            currentMaskCount.runTimeValue -= 1;
            Shoot(mask);

            playerMaskShootEvent.Raise();
        }
    }

    public void OnShootVaccineInput()
    {
        if (currentVaccineCount.runTimeValue > 0 && Time.time > _nextShotTime)
        {
            currentVaccineCount.runTimeValue -= 1;

            Shoot(vaccine);
            playerVaccineShootEvent.Raise();
        }
    }

    public void OnScreamInput()
    {
        if (!canScream) return;
        
        
        // Enforce social distancing in a "scream" radius around the player
        canScream = !canScream;
        _lastBubbleTime = Time.time;
        _nextBubbleTime = Time.time + bubbleCd/1000;
        screamBubble.gameObject.SetActive(true);
        _screamInteraction.SocialDistancing();


    }
    
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSystem : MonoBehaviour
{
    [SerializeField] private GameEvent tickEvent;
    
    private const float TICK_TIMER_THRESHOLD = .6f;
    private float _tick;
    private float _tickTimer;

    private void Update()
    {
        UpdateTick();
    }

    // Tick used for events such as proximity infection, infection spread, etc
    private void UpdateTick()
    {
        _tickTimer += Time.deltaTime;
        if (_tickTimer >= TICK_TIMER_THRESHOLD)
        {
            _tickTimer -= TICK_TIMER_THRESHOLD;
            _tick++;
            
            tickEvent.Raise();
        }
    }
}

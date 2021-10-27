using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;

public class InfectedArea : MonoBehaviour
{
    private Animator _anim;
    public GameEvent infectionSpreadEvent;
    public GameEvent disinfectedEvent;
    public float spreadTime; // rate at which player loses points

    private bool _isDisinfectable = true;
    
    private static readonly int IsDisinfected = Animator.StringToHash("isDisinfected");

    private float _lastSpread;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _lastSpread = Time.time;
    }

    private void Update()
    {
        // Lose points
        if (Time.time > _lastSpread + spreadTime)
        {
            infectionSpreadEvent.Raise();
            _lastSpread = Time.time;
        }
    }

    public void OnDisinfected()
    {
        // avoid re-accessing object in between destruction time
        if (!_isDisinfectable) return;

        _isDisinfectable = false;
        _anim.SetBool(IsDisinfected, true);
        disinfectedEvent.Raise();
        Destroy(gameObject, 1f);
    }
}

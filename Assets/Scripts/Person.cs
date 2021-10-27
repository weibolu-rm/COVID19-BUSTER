using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum PersonState
{
    Wandering,
    Isolating,
    Interacting,
    Leaving
}

public class Person : Character
{
    [SerializeField] private PersonController personController;
    [SerializeField] private float leaveTimer;
    [SerializeField] private float infectionSpreadCd;
    [SerializeField] private InfectedArea infectedAreaPrefab;
    
    public PersonState currentState;
    public bool hadFirstDose;
    public bool hadSecondDose;
    public bool isInfected;
    public bool isVulnerable;
    
    public Transform isolationArea;
    

    public GameEvent infectedEvent;
    public PersonController PersonController => personController;

    private bool _inGameArea;
    private float _spawnTime;
    private float _lastInfectionSpreadTime;

    protected override void Start()
    {
        base.Start();
        Initialize();
        _spawnTime = Time.time;
        _lastInfectionSpreadTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > _spawnTime + leaveTimer)
        {
            // Aight ima head out
            Leave();
        }

        if (isInfected && Time.time > _lastInfectionSpreadTime + infectionSpreadCd)
        {
            ChanceToContaminate();
        }
    }


    private void ChanceToContaminate()
    {
        if (!_inGameArea) return;
        
        _lastInfectionSpreadTime = Time.time;
        
        // 50% chance
        if (!Probabilities.ChooseBasedOnProbability(Probability.Medium)) return;
        
        Instantiate(infectedAreaPrefab, transform.position, Quaternion.identity);
    }
    
    
    private void Initialize()
    {
        currentState = PersonState.Wandering;
        
        hadFirstDose = Probabilities.ChooseBasedOnProbability(Probability.Medium);
        if (hadFirstDose)
        {
            hadSecondDose = Probabilities.ChooseBasedOnProbability(Probability.Low);
        }
        
        if (Probabilities.ChooseBasedOnProbability(Probability.Low))
        {
            WearMask();
        }
        
        if (hadSecondDose) return;
        
        isInfected = isVulnerable switch
        {
            true => Probabilities.ChooseBasedOnProbability(Probability.Medium),
            false => Probabilities.ChooseBasedOnProbability(Probability.Low)
        };
        
    }

    public void SetIsolationArea(Transform area)
    {
        isolationArea = area;
    }

    public void SetInGameArea()
    {
        _inGameArea = true;
    }

    public void SetOutsideGameArea()
    {
        _inGameArea = false;
    }
    
    public void EngageInSocialDistancing()
    {
        personController.SetDistance(1.5f);
    }

    public void GetInfected()
    {
        // Don't want to lose points w/o even seeing the person
        if (!_inGameArea) return;
        
        isInfected = true;
        infectedEvent.Raise();
    }

    // Visual effect to help spot infected people
    private void InfectedFlash()
    {
        if (isInfected)
        {
            CharacterSprite.color = CharacterSprite.color != Color.red ? Color.red : Color.white;
        }
    }

    public void OnTickEvent()
    {
        InfectedFlash();
    }


    private void Leave()
    {
        currentState = PersonState.Leaving;
        personController.ChangeTarget(isolationArea);
    }

    public void SendToIsolation()
    {
        currentState = PersonState.Isolating;
        personController.ChangeTarget(isolationArea);
    }
    
}

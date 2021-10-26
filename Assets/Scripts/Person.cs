using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum PersonState
{
    Wandering,
    Isolating,
    Interacting
}

public class Person : Character
{
    [SerializeField] private PersonController personController;
    public PersonState currentState;
    public bool hadFirstDose;
    public bool hadSecondDose;
    public bool isInfected;
    public bool isVulnerable;
    public bool isIsolating;

    public GameEvent infectedEvent;
    public PersonController PersonController => personController;

    protected override void Start()
    {
        base.Start();
        Initialize();
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

    public void GetInfected()
    {
        isInfected = true;
        infectedEvent.Raise();
    }

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
    

}

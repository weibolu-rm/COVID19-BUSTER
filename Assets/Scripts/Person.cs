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


    protected override void Start()
    {
        base.Start();
        Initialize();
    }

    private void Initialize()
    {
        currentState = PersonState.Wandering;
        
        hadFirstDose = Probabilities.ChooseBasedOnProbability(Probability.Medium);
        hadSecondDose = Probabilities.ChooseBasedOnProbability(Probability.Low);
        
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
    
    public PersonController PersonController => personController;

}

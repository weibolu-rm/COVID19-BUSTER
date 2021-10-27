using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField] private Person person;
    
    [SerializeField] private GameObject vulnerable;
    [SerializeField] private GameObject infected;
    [SerializeField] private GameObject firstDose;
    [SerializeField] private GameObject secondDose;
    [SerializeField] private GameObject isolating;

    public GameObject Vulnerable => vulnerable;
    public GameObject Infected => infected;
    public GameObject FirstDose => firstDose;
    public GameObject SecondDose => secondDose;
    public GameObject Isolating => isolating;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (person.hadFirstDose)
        {
           EnableIndicator(firstDose); 
        }

        if (person.hadSecondDose)
        {
            EnableIndicator(secondDose);
        }

        if (person.isInfected)
        {
            EnableIndicator(infected);
        }

        if (person.isVulnerable)
        {
            EnableIndicator(vulnerable);
        }

        if (person.currentState == PersonState.Isolating)
        {
            EnableIndicator(isolating);
            DisableIndicator(firstDose);
            DisableIndicator(secondDose);
            DisableIndicator(infected);
            DisableIndicator(vulnerable);
        }
    }

    private void EnableIndicator(GameObject indicator)
    {
        indicator.SetActive(true);
    }
    
    public void DisableIndicator(GameObject indicator)
    {
        indicator.SetActive(false);
    }

}

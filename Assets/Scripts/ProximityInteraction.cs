using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityInteraction : PeopleProximitySensor
{
    [SerializeField] private Person person;
    public void OnTickEvent()
    {
        if (ProximityCount == 0) return;
        
        ChanceToInfect();
    }

    private void ChanceToInfect()
    {
        if (!person.isInfected) return;

        foreach (var other in ProximityList)
        {
            // Second dose = immune
            if (other.hadSecondDose) continue;
            
            bool willGetInfected = false;
            
            // First roll
            switch (person.IsWearingMask)
            {
                case true:
                {
                    // Mask = low chance of infection
                    if (Probabilities.ChooseBasedOnProbability(Probability.Low))
                    {
                        willGetInfected = true;
                    } break;
                }
                case false:
                {
                    // No Mask = medium chance of infection
                    if (Probabilities.ChooseBasedOnProbability(Probability.Medium))
                    {
                        willGetInfected = true;
                    } break;
                }
            }
            
            // Second roll
            switch (other.isVulnerable)
            {
                case true:
                {
                    // Mask & vulnerable = Medium chance of infection
                    if (Probabilities.ChooseBasedOnProbability(Probability.Medium))
                    {
                        willGetInfected = true;
                    } break;
                }
                case false:
                {
                    // No Mask  & vulnerable = high chance of infection
                    if (Probabilities.ChooseBasedOnProbability(Probability.High))
                    {
                        willGetInfected = true;
                    } break;
                }
            }

            if (willGetInfected)
            {
                other.GetInfected();
            }
        }

    }

}
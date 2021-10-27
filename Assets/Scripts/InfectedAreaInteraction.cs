using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfectedAreaInteraction : PeopleProximitySensor
{

    public void OnTickEvent()
    {
        if (ProximityCount == 0) return;
        
        ChanceToInfect();
    }

    private void ChanceToInfect()
    {
        foreach (var other in ProximityList)
        {
            if (other.hadSecondDose) return;

            switch (other.isVulnerable)
            {
                case true:
                    if (Probabilities.ChooseBasedOnProbability(Probability.High))
                    {
                        other.GetInfected();
                        return;
                    }
                    break;
                case false:
                    if (Probabilities.ChooseBasedOnProbability(Probability.Medium))
                    {
                        other.GetInfected();
                        return;
                    }
                    break;
            }

        }
        
    }
    
}

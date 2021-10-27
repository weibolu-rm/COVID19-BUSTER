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
        // Can only infect others when infected..
        if (!person.isInfected) return;

        foreach (var other in ProximityList)
        {
            // Second dose = immune
            if (other.hadSecondDose) continue;
            
            bool willGetInfected = false;
            int rolls = 1;

            // If person is vulnerable, they get two rolls, i.e. twice as likely to be infected
            if (other.isVulnerable) rolls = 2;

            while (rolls > 0)
            {
                
                switch (person.IsWearingMask)
                {
                    case true:
                    {
                        // if both are wearing masks, then don't infect.
                        if (other.IsWearingMask) return;

                        if (other.hadFirstDose)
                        {
                            //  infected is wearing mask + other had first dose
                            if(Probabilities.ChooseBasedOnProbability(Probability.VeryLow))
                            {
                                willGetInfected = true;
                            }
                        }
                        // infected is wearking mask + other not vaccinated
                        else if (Probabilities.ChooseBasedOnProbability(Probability.Low))
                        {
                            willGetInfected = true;
                        } break;
                    }
                    case false:
                    {
                        if (other.hadFirstDose)
                        {
                            //  infected is not wearing mask + other had first dose
                            if(Probabilities.ChooseBasedOnProbability(Probability.Low))
                            {
                                willGetInfected = true;
                            }
                        }
                        // No Mask + No vaccine = medium chance of infection (this is happening every tick, not a one chance thing, so it's still pretty high)
                        else if (Probabilities.ChooseBasedOnProbability(Probability.Medium))
                        {
                            willGetInfected = true;
                        } break;
                    }
                }

                rolls--;
            }


            if (willGetInfected)
            {
                other.GetInfected();
            }
        }

    }

}
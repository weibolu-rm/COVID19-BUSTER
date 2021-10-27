using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerToPeopleInteraction : PeopleProximitySensor
{
    public GameEvent socialDistancingEvent;
    public GameEvent isolationEvent;

    // yo 2m apart
    public void SocialDistancing()
    {
            
        foreach (var person in ProximityList)
        {
            if (ProximityCount >= 2)
            {
                socialDistancingEvent.Raise();
            }
            person.EngageInSocialDistancing();
        }
    }

    public void SendToIsolation()
    {
        
        foreach (var person in ProximityList)
        {
            if (person && person.isInfected)
            {
                if (person.currentState == PersonState.Isolating) return; // already isolating
                
                person.SendToIsolation();
                isolationEvent.Raise();
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreamInteraction : PeopleProximitySensor
{
    public GameEvent socialDistancingEvent;

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


}

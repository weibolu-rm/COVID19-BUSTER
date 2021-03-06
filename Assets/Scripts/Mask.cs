using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : Projectile
{
    public GameEvent maskEvent;

    private void WearMask(Person person)
    {
        if (person.IsWearingMask) return;
        
        person.WearMask();
        maskEvent.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("People"))
        {
            var person = other.GetComponent<Person>();
            WearMask(person);
        }
        Destroy(gameObject);
    }
}

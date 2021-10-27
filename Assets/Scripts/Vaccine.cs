using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : Projectile
{
    public GameEvent firstDoseEvent;
    public GameEvent secondDoseEvent;

    private void Vaccinate(Person person)
    {
        if (person.hadSecondDose) return;
        
        if (!person.hadFirstDose)
        {
            person.hadFirstDose = true;
            firstDoseEvent.Raise();
        }
        // Immune on second dose
        else if (!person.hadSecondDose)
        {
            person.hadSecondDose = true;
            secondDoseEvent.Raise();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("People"))
        {
            var person = other.GetComponent<Person>();
            Vaccinate(person);
            
        }
        Destroy(gameObject);
    }
}

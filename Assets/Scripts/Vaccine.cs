using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : Projectile
{
    public GameEvent firstDoseEvent;
    public GameEvent secondDoseEvent;

    public void Vaccinate(Person person)
    {
        if (person.isImmune) return;
        
        if (!person.hadFirstDose)
        {
            person.hadFirstDose = true;
            firstDoseEvent.Raise();
        Debug.Log("FIRST DOSE EVENT");
        }
        // Immune on second dose
        else if (!person.isImmune)
        {
            person.isImmune = true;
            secondDoseEvent.Raise();
            Debug.Log("SECOND DOSE EVENT");
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

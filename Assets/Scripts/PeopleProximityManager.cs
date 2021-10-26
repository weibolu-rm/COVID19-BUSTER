using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PeopleProximityManager : MonoBehaviour
{
    [SerializeField] private Person person;
    private List<Person> _proximityList = new List<Person>();
    private int _proximityCount;

    public void OnTickEvent()
    {
        if (_proximityCount == 0) return;
        
        ChanceToInfect();
    }

    private void ChanceToInfect()
    {
        if (!person.isInfected) return;

        foreach (var other in _proximityList)
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
                Debug.Log("INFECTION SPREAD!!!");
            }
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("People"))
        {
            var otherPerson = other.GetComponent<Person>();
            _proximityList.Add(otherPerson);
            _proximityCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("People"))
        {
            var otherPerson = other.GetComponent<Person>();
            _proximityList.Remove(otherPerson);
            _proximityCount--;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PeopleProximitySensor : MonoBehaviour
{
    protected List<Person> ProximityList = new List<Person>();
    protected int ProximityCount;

    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("People"))
        {
            var otherPerson = other.GetComponent<Person>();
            ProximityList.Add(otherPerson);
            ProximityCount++;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("People"))
        {
            var otherPerson = other.GetComponent<Person>();
            ProximityList.Remove(otherPerson);
            ProximityCount--;
        }
    }
}

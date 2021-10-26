using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionSpreader : MonoBehaviour
{

    [SerializeField] private GameObject creeper;
    public bool canSpawn = true;


    public void Infect()
    {
        Instantiate(creeper, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canSpawn && other.CompareTag("Walls"))
        {
            canSpawn = false;
        }

        if (canSpawn && other.CompareTag("Infection"))
        {
            canSpawn = false;
        }
    }
}

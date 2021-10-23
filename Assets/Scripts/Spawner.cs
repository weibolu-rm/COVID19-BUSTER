using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Person> persons = new List<Person>();
    [SerializeField] private List<Transform> targets;
    private List<Transform> _spawns = new List<Transform>();
    

    private int _childCount;
    // Start is called before the first frame update
    private void Start()
    {
        _childCount = transform.childCount;
        for (int i = 0; i < _childCount; i++)
        {
           _spawns.Add(transform.GetChild(i)); 
        }
        
    }

    // Update is called once per frame
    private void Update()
    {


    }

    private void Spawn()
    {
        Vector3 pos = _spawns[Random.Range(0, _childCount)].position;
        Person person = persons[Random.Range(0, persons.Count)];

        person.PersonController.SetTargetsList(ref targets);
        person.PersonController.ChangeTarget();

        // Spawn prefab -> pass target list -> choose random target
        Instantiate(person, pos, Quaternion.identity);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] float spawnCd = 10f;
    [SerializeField] private FloatValue scoreCounter;
    [SerializeField] private GameEvent scoreUpdateEvent;
    
    public GameEvent spawnEvent;
    public GameEvent gameEndedEvent;

    private bool _gameShouldEnd = false;


    private float _lastSpawnTime;

    private void Start()
    {
        _lastSpawnTime = Time.time;
        
    }

    private void Update()
    {
        if (Time.time > _lastSpawnTime + spawnCd)
        {
            _lastSpawnTime = Time.time;
            SpawnPerson();
        }

        if (_gameShouldEnd)
        {
            gameEndedEvent.Raise();
        }
    }

    
    public void UpdateScore(float scoreDelta)
    {
        scoreCounter.runTimeValue += scoreDelta;
        scoreUpdateEvent.Raise();
        if (scoreCounter.runTimeValue <= -20)
        {
            _gameShouldEnd = true;
        }
    }
    
    private void SpawnPerson()
    {
        Debug.Log("Spawned");
        spawnEvent.Raise();
    }
    
    
}

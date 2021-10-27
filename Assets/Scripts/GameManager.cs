using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] float spawnCd = 10f;
    [SerializeField] private FloatValue scoreCounter;
    [SerializeField] private FloatValue highestScore;
    [SerializeField] private GameEvent scoreUpdateEvent;
    
    public GameEvent spawnEvent;
    public GameEvent gameEndedEvent;

    private bool _gameShouldEnd = false;


    private float _lastSpawnTime;
    private float _lvlIncreaseTime;

    private void Start()
    {
        _lastSpawnTime = Time.time;
        SpawnPerson();
        
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
            // for the highscore to get the update
            scoreUpdateEvent.Raise();
        }
    }


    
    public void UpdateScore(float scoreDelta)
    {
        scoreCounter.runTimeValue += scoreDelta;
        // Update Highest Score
        if (scoreCounter.runTimeValue > highestScore.runTimeValue)
        {
            highestScore.runTimeValue = scoreCounter.runTimeValue;
        }
            
        scoreUpdateEvent.Raise();
        if (scoreCounter.runTimeValue <= -20)
        {
            _gameShouldEnd = true;
        }
    }
    
    private void SpawnPerson()
    {
        spawnEvent.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("People"))
        {
            var otherPerson = other.GetComponent<Person>();
            otherPerson.SetInGameArea();
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("People"))
        {
            var otherPerson = other.GetComponent<Person>();
            otherPerson.SetOutsideGameArea();
        }
    }
}

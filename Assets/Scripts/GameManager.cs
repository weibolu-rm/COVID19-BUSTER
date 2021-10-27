using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float spawnCd = 10f;
    [SerializeField] private float specialModeCd = 30f;
    [SerializeField] private float specialModeDuration = 3f;
    [SerializeField] private float levelIncreaseCd = 30f;
    [SerializeField] private float comboThreshold = 2f;
    [SerializeField] private float maskComboAmount = 2f;
    
    // Float references
    [SerializeField] private FloatValue scoreCounter;
    [SerializeField] private FloatValue highestScore;

    // Move speeds to be updated 
    [SerializeField] private FloatValue playerMoveSpeed;
    [SerializeField] private FloatValue charAMoveSpeed;
    [SerializeField] private FloatValue charBMoveSpeed;
    [SerializeField] private FloatValue charCMoveSpeed;

    [SerializeField] private PostProcessVolume ppv;
    
    // Events raised by GameManager
    public GameEvent spawnEvent;
    public GameEvent gameEndedEvent;
    public GameEvent scoreUpdateEvent;

    private bool _gameShouldEnd = false;
    private bool _specialMode = false;
    

    private const int WAVE_SIZE = 8;

    private float _lastSpawnTime;
    private float _lastLvlIncreaseTime;
    private float _lastSpecialTime;
    private float _lastMaskTime;

    private void Start()
    {
        
        // Post processing for special mode
        ppv.gameObject.SetActive(true);
        ppv.enabled = false;
        
        _lastSpawnTime = 0;
        _lastMaskTime = Time.time;
        _lastSpecialTime = -specialModeCd;
        _lastLvlIncreaseTime = Time.time;
        SpawnPerson();
        
    }

    private void Update()
    {
        // Regular spawn timer
        if (Time.time > _lastSpawnTime + spawnCd)
        {
            _lastSpawnTime = Time.time;
            SpawnPerson();
        }

        // Increase in level difficulty
        if (Time.time > _lastLvlIncreaseTime + levelIncreaseCd)
        {
            LevelIncrease();
        }

        // Reset special mode
        if (_specialMode && Time.time > _lastSpecialTime + specialModeDuration)
        {
            _specialMode = false;
            playerMoveSpeed.runTimeValue = playerMoveSpeed.initialValue;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            ppv.enabled = false;
        }

        // Points <= -20
        if (_gameShouldEnd)
        {
            gameEndedEvent.Raise();
            // for the highscore to get the update
            scoreUpdateEvent.Raise();
        }
    }

    // Increases the spawn speed, and move speed of people
    // Also chance to spawn a wave of people
    private void LevelIncrease()
    {
        _lastLvlIncreaseTime = Time.time;
        if (spawnCd > 1f)
        {
            spawnCd -= 0.5f;
        }

        // Chance to spawn a wave of people
        if (Probabilities.ChooseBasedOnProbability(Probability.Medium))
        {
            SpawnWaveOfPeople();
        }

        charAMoveSpeed.runTimeValue += Random.value;
        charBMoveSpeed.runTimeValue += Random.value;
        charCMoveSpeed.runTimeValue += Random.value;
    }


    // Spawn wave of people 
    private void SpawnWaveOfPeople()
    {
        Debug.Log("WAVE OF PEOPLE!!!");
        for (int i = 0; i < WAVE_SIZE; i++)
        {
            spawnEvent.Raise();
        }
    }

    
    public void UpdateScore(float scoreDelta)
    {
        if (!_specialMode)
        {
            scoreCounter.runTimeValue += scoreDelta;
        }
        else
        {
            // Limiting score to 1 pt for good, and -2 for bad
            if (scoreDelta > 0)
            {
                scoreCounter.runTimeValue += 1;
            }
            else
            {
                scoreCounter.runTimeValue -= 2;
            }
        }
        
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
    
    // Activate special mode -> slows down time and speeds up player
   public void OnSpecialModeInput()
   {
       if (!(Time.time > _lastSpecialTime + specialModeCd)) return;
       
       Debug.Log("SPECIAL MODE");
       ppv.enabled = true;
       _specialMode = true;
       SpawnWaveOfPeople();
       _lastSpecialTime = Time.time;
       playerMoveSpeed.runTimeValue = 15f;
       Time.timeScale = .3f;
       Time.fixedDeltaTime = 0.02f * Time.timeScale;

   }

   // Handles combos if two masks have been handed out in a given time
   public void OnMaskEvent(float regular)
   {
       if (Time.time - _lastMaskTime <= comboThreshold)
       {
           Debug.Log("Combo");
           _lastMaskTime = Time.time;
           UpdateScore(maskComboAmount + regular);
       }
       else
       {
           _lastMaskTime = Time.time;
           UpdateScore(regular);
       }
   }
    // In game area to avoid losing points from people that aren't even seen
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

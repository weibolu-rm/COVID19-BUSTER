using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PersonController : MonoBehaviour
{
	[SerializeField] private MapManager mapManager;
	
	[SerializeField] private Transform currentTarget;
	[SerializeField] private Person person;
	[SerializeField] private float timeBetweenTargets = 20f;
	
    [SerializeField] List<Transform> targets;
	
	private NavMeshAgent _agent;
	private Vector2 _direction;
	private float _lastTargetSwitchTime;


	public void SetTargetsList( ref List<Transform> targetList)
	{
		this.targets = targetList;
	}

	public bool GetTileAtPositionData()
	{
		return mapManager.GetTileInfectedData(person.transform.position);
	}


	private void Start()	{
		_agent = GetComponent<NavMeshAgent>();
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;
		_agent.speed = person.GetMoveSpeed();
		_lastTargetSwitchTime = Time.time;
	}
	
    private void Update()
    {
	    if (currentTarget && person.currentState != PersonState.Interacting)
	    {
			var targetPosition = currentTarget.position;
			_agent.SetDestination(targetPosition);
			_direction = (Vector2) (targetPosition - transform.position);
	    }

	    // If leaving or isolating, stop changing states randomly
	    if (Time.time > _lastTargetSwitchTime + timeBetweenTargets && person.currentState == PersonState.Wandering)
	    {
		    ChangeTarget();
	    }
        ChangeSprites();
    }


    // For social distancing
    public void SetDistance(float radius)
    {
	    _agent.radius = radius;
    }
    
    // Assign a random target
    public void ChangeTarget()
    {
	    currentTarget = targets[Random.Range(0, targets.Count)];
	    _lastTargetSwitchTime = Time.time;
    }
    
    // Choose target to assign
    public void ChangeTarget(Transform target)
    {
	    Debug.Log("CHANGE TARGET");
	    currentTarget = target;
	    var targetPosition = currentTarget.position;
	    _agent.SetDestination(targetPosition);
	    _lastTargetSwitchTime = Time.time;
    }
    
    
    
    private void ChangeSprites()
    {
        if (_direction == Vector2.zero) return;
        
        // Using abs to see if person is moving MORE horizontally or vertically
        if (_direction.y > 0 && math.abs(_direction.y) > math.abs(_direction.x))
        {
            person.SetSpritesUp();
        }
        else if (_direction.y < 0 && math.abs(_direction.y) > math.abs(_direction.x))
        {
            person.SetSpritesDown();
        }
        else if (_direction.x > 0 && math.abs(_direction.x) > math.abs(_direction.y))
        {
            person.SetSpritesRight();
        }
        else if (_direction.x < 0 && math.abs(_direction.x) > math.abs(_direction.y))
        {
            person.SetSpritesLeft();
        }
    }
}

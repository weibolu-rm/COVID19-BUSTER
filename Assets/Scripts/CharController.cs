using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Character character;
	
	private NavMeshAgent _agent;
	private Vector2 _direction;

	private void Start()	{
		_agent = GetComponent<NavMeshAgent>();
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;
		_agent.speed = character.GetMoveSpeed();
	}
	
    private void Update()
    {
	    var targetPosition = target.position;
	    _agent.SetDestination(targetPosition);
	    _direction = (Vector2) (targetPosition - transform.position);

        ChangeSprites();
    }
    
    
    private void ChangeSprites()
    {
        if (_direction == Vector2.zero) return;
        
        // Using abs to see if character is moving MORE horizontally or vertically
        if (_direction.y > 0 && math.abs(_direction.y) > math.abs(_direction.x))
        {
            character.SetSpritesUp();
        }
        else if (_direction.y < 0 && math.abs(_direction.y) > math.abs(_direction.x))
        {
            character.SetSpritesDown();
        }
        else if (_direction.x > 0 && math.abs(_direction.x) > math.abs(_direction.y))
        {
            character.SetSpritesRight();
        }
        else if (_direction.x < 0 && math.abs(_direction.x) > math.abs(_direction.y))
        {
            character.SetSpritesLeft();
        }
    }
}

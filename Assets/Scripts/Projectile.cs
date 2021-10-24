using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifetime = 10f; 

    private float _spawnTime;

    private void Start()
    {
        _spawnTime = Time.time;
    }

    // I'll call this myself, as opposed to Start()
    public void Initialize(Vector2 forward)
    {
        // transform.Translate( Vector3.right * speed * Time.deltaTime);
        rb.velocity = forward * speed;
    }

    private void Update()
    {
        if (Time.time > _spawnTime + lifetime)
        {
            if (gameObject)
            {
                Destroy(gameObject);
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Destroy(gameObject);
    //     
    //     // INTERACT WITH PEOPLE
    // }
}

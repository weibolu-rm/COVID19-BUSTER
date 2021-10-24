using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    
    private void Update()
    {
        transform.Translate( Vector3.right * speed * Time.deltaTime);
    }


    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    
    [SerializeField] private PlayerController playerController;
    [SerializeField] Rigidbody2D rb;
    public Rigidbody2D Rigidbody2D => rb;



    
    
    public PlayerController PlayerController => playerController;
    




    
}


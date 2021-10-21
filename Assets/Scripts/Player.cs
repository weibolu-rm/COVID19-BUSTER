using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;
    [SerializeField] Rigidbody2D rb;

    [Header("Player Stats")] [SerializeField]
    private float moveSpeed;
    
    
    public Animator Animator => animator;
    public PlayerController PlayerController => playerController;
    public Rigidbody2D Rigidbody2D => rb;


    

    public float GetMoveSpeed()
    {
        // possibility to add functionality
        return moveSpeed;
    }
}


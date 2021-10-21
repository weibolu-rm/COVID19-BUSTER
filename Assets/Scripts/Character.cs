using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [Header("Sprite fields")]
    [SerializeField] private SpriteRenderer characterSprite;
    [SerializeField] private SpriteRenderer maskSprite;
    [SerializeField] private SpriteRenderer clotheSprite;
    [SerializeField] private SpriteRenderer hairSprite;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite upHairSprite;
    [SerializeField] private Sprite downHairSprite;
    [SerializeField] private Sprite leftHairSprite;
    [SerializeField] private Sprite rightHairSprite;
    [SerializeField] private Sprite upClotheSprite;
    [SerializeField] private Sprite downClotheSprite;
    [SerializeField] private Sprite leftClotheSprite;
    [SerializeField] private Sprite rightClotheSprite;
    [SerializeField] private Sprite upMaskSprite;
    [SerializeField] private Sprite downMaskSprite;
    [SerializeField] private Sprite leftMaskSprite;
    [SerializeField] private Sprite rightMaskSprite;

    [SerializeField] Rigidbody2D rb;
    
    
    [Header("Player Stats")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isWearingMask;
    
    private Sprite _upMaskSprite = null;
    private Sprite _downMaskSprite = null;
    private Sprite _leftMaskSprite = null;
    private Sprite _rightMaskSprite = null;

    public Rigidbody2D Rigidbody2D => rb;
    private void Awake()
    {
    }

    private void Start()
    {
        if (isWearingMask)
        {
            wearMask();
        }
    }

    private void Update()
    {
        // FOR DEBUG
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        
        if(mouse.leftButton.isPressed)
            wearMask();
    }

    public float GetMoveSpeed()
    {
        // possibility to add functionality
        return moveSpeed;
    }
    public void SetSpritesLeft()
    {
        characterSprite.sprite = leftSprite;
        clotheSprite.sprite = leftClotheSprite;
        maskSprite.sprite = _leftMaskSprite;
        hairSprite.sprite = leftHairSprite;
        
    }
    public void SetSpritesRight()
    {
        characterSprite.sprite = rightSprite;
        clotheSprite.sprite = rightClotheSprite;
        maskSprite.sprite = _rightMaskSprite;
        hairSprite.sprite = rightHairSprite;
    }
    public void SetSpritesUp()
    {
        characterSprite.sprite = upSprite;
        clotheSprite.sprite = upClotheSprite;
        maskSprite.sprite = _upMaskSprite;
        hairSprite.sprite = upHairSprite;
    }
    public void SetSpritesDown()
    {
        characterSprite.sprite = downSprite;
        clotheSprite.sprite = downClotheSprite;
        maskSprite.sprite = _downMaskSprite;
        hairSprite.sprite = downHairSprite;
    }

    public void wearMask()
    {
        isWearingMask = true;
        _downMaskSprite = downMaskSprite;
        _upMaskSprite = upMaskSprite;
        _leftMaskSprite = leftMaskSprite;
        _rightMaskSprite = rightMaskSprite;
        SetSpritesDown();
    }
}

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
    
    
    [Header("Player Stats")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isWearingMask;
    
    private Sprite _upMaskSprite = null;
    private Sprite _downMaskSprite = null;
    private Sprite _leftMaskSprite = null;
    private Sprite _rightMaskSprite = null;


    protected Vector3 Forward = Vector3.down;

    public bool IsWearingMask => isWearingMask;

    private void Start()
    {
        if (isWearingMask)
        {
            WearMask();
        }
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
        Forward = Vector3.left; 
    }
    public void SetSpritesRight()
    {
        characterSprite.sprite = rightSprite;
        clotheSprite.sprite = rightClotheSprite;
        maskSprite.sprite = _rightMaskSprite;
        hairSprite.sprite = rightHairSprite;
        Forward = Vector3.right; 
    }
    public void SetSpritesUp()
    {
        characterSprite.sprite = upSprite;
        clotheSprite.sprite = upClotheSprite;
        maskSprite.sprite = _upMaskSprite;
        hairSprite.sprite = upHairSprite;
        Forward = Vector3.up; 
    }
    public void SetSpritesDown()
    {
        characterSprite.sprite = downSprite;
        clotheSprite.sprite = downClotheSprite;
        maskSprite.sprite = _downMaskSprite;
        hairSprite.sprite = downHairSprite;
        Forward = Vector3.down; 
    }

    public void WearMask()
    {
        isWearingMask = true;
        _downMaskSprite = downMaskSprite;
        _upMaskSprite = upMaskSprite;
        _leftMaskSprite = leftMaskSprite;
        _rightMaskSprite = rightMaskSprite;
        SetSpritesDown();
    }
}

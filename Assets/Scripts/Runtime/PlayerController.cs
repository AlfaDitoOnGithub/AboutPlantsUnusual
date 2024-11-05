using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mSpd = 2f;
    private PlayerAnimator _playerAnimator; 
    // private bool lastHMoveRight;
   
    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if ((horizontal !=0) || (vertical !=0))
        {
            _playerAnimator.playRunAnimation();

            if(horizontal > 0.000001f){
                _playerAnimator.flipSprite(false);
            }
            if(horizontal < -0.000001f){
                _playerAnimator.flipSprite(true);
            }
        }
        else
        {
            _playerAnimator.playIdleAnimation();
        }
        
        Vector2 direction = new Vector2(horizontal, vertical);
        transform.Translate(direction * mSpd * Time.deltaTime);

    }

    void Attack(){
        //manages player attack melee or range
    }

    void Hurt(){
        //manages player health and damage taken

    }

}

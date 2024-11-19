using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class HurtboxController : MonoBehaviour
{
    [SerializeField] private bool enemyAttack = false;
    private PlayerAnimator _playerAnimator; 
    private Rigidbody2D _rb;
   
   
    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _rb = GetComponent<Rigidbody2D>();
    }
     public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("EnemyAttack"))
       {
        enemyAttack = true;
        
        Debug.Log("Attack musuh Masuk");
       }
   }

   public void OnTriggerExit2D(Collider2D other)
   {
       if (other.CompareTag("EnemyAttack"))
       {
        enemyAttack = false;
        Debug.Log("Attack musuh tidak ada Keluar");
        
       }
   }
    
    void Update()
    {
        if (enemyAttack)
        {
            //do something
        }
    }

   
    void Attack(){
        //manages player attack melee or range
    }

    void Hurt(){
        //manages player health and damage taken
       

    }

}
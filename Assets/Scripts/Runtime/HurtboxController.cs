using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class HurtboxController : MonoBehaviour
{
     private bool enemyAttack = false;
    
    
    private PlayerAnimator _playerAnimator; 
    // private Rigidbody2D _rb;
    public HealthSystem playerHealth;


    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        // _rb = GetComponent<Rigidbody2D>();
        playerHealth = new HealthSystem(10);
    }
     public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Enemy"))
       {
        enemyAttack = true;
        
        Debug.Log("Attack musuh Masuk");
       }
   }

   public void OnTriggerExit2D(Collider2D other)
   {
       if (other.CompareTag("Enemy"))
       {
        enemyAttack = false;
        Debug.Log("Attack musuh tidak ada");
        
       }
   }
    
    void Update()
    {
        if (enemyAttack)
        {
            //do something
            Hurt();
        }
    }



    void Hurt(){
        //manages player health and damage taken
        playerHealth.Damage(1);
       _playerAnimator.playHurtAnimation();
        //if(healthPlayer <= 0){
            //GAME OVER SCREEN
        //}

    }


}

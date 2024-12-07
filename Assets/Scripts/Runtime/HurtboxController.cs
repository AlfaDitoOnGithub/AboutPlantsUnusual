using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CodeMonkey.Utils;


public class HurtboxController : MonoBehaviour
{
    private bool enemyAttack = false;
        
    private PlayerAnimator _playerAnimator; 
    [SerializeField] GameObject _gameOverUI;
    // private Rigidbody2D _rb;
   
    public HealthSystem playerHealth;
    public event EventHandler<healthArgs> healthBarAdj;
    public class healthArgs : EventArgs {
        public int currHealth;
       
    }

    [SerializeField] private float iFramesDuration;


    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        // _rb = GetComponent<Rigidbody2D>();
        playerHealth = new HealthSystem(10);
        

    }
     public void OnTriggerEnter2D(Collider2D hurtbox)
   {
       if (hurtbox.CompareTag("enemy"))
       {
        enemyAttack = true;
        
        Debug.Log("Attack musuh Masuk");
       }
   }

   public void OnTriggerExit2D(Collider2D hurtbox)
   {
       if (hurtbox.CompareTag("enemy"))
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


    [ContextMenu("testHurt")]
    void Hurt(){
        //manages player health and damage taken
        StartCoroutine(Invulnerable());
        playerHealth.Damage(1);
        _playerAnimator.playHurtAnimation();
        SoundManager.PlaySound(SoundType.PlayerHurt);
        healthBarAdj?.Invoke(this, new healthArgs{
            currHealth = playerHealth.GetCurrHealth()
        });

        if(playerHealth.GetCurrHealth() <= 0){
            //GAME OVER SCREEN
            _playerAnimator.playDeadAnimation();
            _gameOverUI.SetActive(true);
            
            Debug.Log("GAME OVER");
        }

    }

    private IEnumerator Invulnerable(){
        Physics2D.IgnoreLayerCollision(6,7, true);
        while(iFramesDuration > 0){
            yield return new WaitForSeconds(2f);
            iFramesDuration--;
        }
        Physics2D.IgnoreLayerCollision(6,7, false);
    }
   


}

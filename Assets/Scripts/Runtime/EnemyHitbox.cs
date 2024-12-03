using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class EnemyHitbox : MonoBehaviour {


// private Transform spriteTransform;
private Animator spriteAnimator;
[SerializeField] private int health = 3;
// private bool bulletContact =false;
private HealthSystem enemyHealth;

    private void Start()
    {
        // spriteTransform = transform.Find("Sprite");
        spriteAnimator = GetComponent<Animator>();
        enemyHealth = new HealthSystem(health);
    }

    // private void Update(){
    //     if()
    // }
    public void Damage() {
        //enemy hurt animation is trigger
        spriteAnimator.SetTrigger("Damage");
        SoundManager.PlaySound(SoundType.EnemyDamaged);
        enemyHealth.Damage(1);
        if(enemyHealth.GetCurrHealth() <= 0){
            spriteAnimator.SetBool("IsDead",true);
            SoundManager.PlaySound(SoundType.EnemyDeath);
        }


    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Projectile_player")){
            Debug.Log("COLLISIONS with bullet");
            Damage();
        }
    }

    private void DestroyOnAnimationEnd(){
        Destroy(gameObject);
    }
    
    // public Vector3 GetPosition(){
    //     return transform.position;
    // }
}
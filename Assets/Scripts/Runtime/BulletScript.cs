using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BulletScript : MonoBehaviour
{
   private Vector3 shootDir;
   //private Rigidbody2D _rb;
   
   public void Setup(Vector3 shootDir){
    this.shootDir = shootDir;
    Destroy(gameObject, 3f);
   }

   
   private void Update()
   {
       float moveSpeed = 100f;
       transform.position += shootDir * moveSpeed * Time.deltaTime;
       //_rb.velocity = shootDir * moveSpeed;
   }

   
   private void OnTriggerEnter2D(Collider2D collider)
   {    EnemyHitbox enemy = collider.GetComponent<EnemyHitbox>();
    if ( enemy != null)
    {
         enemy.Damage();
         Destroy(gameObject);
    }       
   }
}

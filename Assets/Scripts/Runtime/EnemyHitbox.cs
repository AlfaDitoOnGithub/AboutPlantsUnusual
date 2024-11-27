using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class EnemyHitbox : MonoBehaviour {

private static List<EnemyHitbox> enemyList;
private Animator spriteAnimator;
    private void Awake()
    {
        if (enemyList == null){enemyList = new List<EnemyHitbox>();};
        enemyList.Add(this);
        spriteAnimator = transform.Find("Sprite").GetComponent<Animator>();
    }
    public void Damage() {
        //enemy hurt animation is trigger
        spriteAnimator.SetTrigger("Hurt");

    }
    public Vector3 GetPosition(){
        return transform.position;
    }
}
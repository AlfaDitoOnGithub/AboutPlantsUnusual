using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }
    public void playRunAnimation()
    {
        _animator.SetBool("IsMoving", true);
    }
    public void playIdleAnimation()
    {
        _animator.SetBool("IsMoving", false);
    }

    public void flipSprite(bool isFlip){
        _spriteRenderer.flipX = isFlip;
    }

    public void playAttackAnimation(){
        _animator.SetTrigger("IsAttack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

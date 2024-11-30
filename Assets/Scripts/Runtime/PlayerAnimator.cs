using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    

    private void Start()
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

    public void playHurtAnimation(){
        _animator.SetTrigger("Hurt");
    }

    public void flipSprite(bool isFlip){
        _spriteRenderer.flipX = isFlip;
    }
}

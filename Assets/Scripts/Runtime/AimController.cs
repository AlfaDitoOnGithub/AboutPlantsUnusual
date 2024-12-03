using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;


public class AimController : MonoBehaviour
{
    
    private Transform aimTransform;
    private Transform gunTransform;
    private Transform gunEndPointTransform;
    private Animator gunAnimator;

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        gunTransform = transform.Find("Aim/gun");
        gunEndPointTransform = transform.Find("Aim/gunEndPointPosition");
        gunAnimator = gunTransform.GetComponent<Animator>();
    }
   
    // Update is called once per frame
    void Update()
    {
        Aiming();
        Shooting();

    }

    private void Aiming(){
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0, angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }else
        {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
    }
    private void Shooting(){
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
       
            gunAnimator.SetTrigger("Shoot");
            OnShoot?.Invoke(this, new OnShootEventArgs{
                gunEndPointPosition = gunEndPointTransform.position,
                shootPosition = mousePosition,
            });
            SoundManager.PlaySound(SoundType.PlayerShoot);
        }
    }

}



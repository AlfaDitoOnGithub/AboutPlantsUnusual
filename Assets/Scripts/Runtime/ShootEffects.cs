using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using Unity.Mathematics;

public class ShootEffects : MonoBehaviour
{
   [SerializeField] private AimController _aimController;
   [SerializeField] private Transform pfBullet;

   private void Start()
   {
       _aimController.OnShoot += AimController_OnShoot;
   }

   private void AimController_OnShoot(object sender, AimController.OnShootEventArgs e){
    //spawn bullet that will travel to mouse position
    Transform bulletTransform = Instantiate(pfBullet, e.gunEndPointPosition, Quaternion.identity);
    
    Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
    bulletTransform.GetComponent<BulletScript>().Setup(shootDir);
   }


}

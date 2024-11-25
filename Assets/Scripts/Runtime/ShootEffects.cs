using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ShootEffects : MonoBehaviour
{
   [SerializeField] private AimController _aimController;

   private void Start()
   {
       _aimController.OnShoot += AimController_OnShoot;
   }

   private void AimController_OnShoot(object sender, AimController.OnShootEventArgs e){
    //spawn bullet that will travel to mouse position
   }


}

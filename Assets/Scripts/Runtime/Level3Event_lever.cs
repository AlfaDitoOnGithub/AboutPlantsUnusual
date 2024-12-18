using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Level3Event_lever : MonoBehaviour
{
   [SerializeField] private bool leverActivate = false;
   [SerializeField] private GameObject uiTextPrompt;
//    [SerializeField] private GameObject gerbang;
   public UnityEvent gateOpen;

   public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
        leverActivate = true;
        uiTextPrompt.SetActive(true);
        Debug.Log("Player Masuk");
       }
   }

   public void OnTriggerExit2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
        leverActivate = false;
        Debug.Log("Player Keluar");
        uiTextPrompt.SetActive(false);
       }
   }

   /// <summary>
   /// Update is called every frame, if the MonoBehaviour is enabled.
   /// </summary>
   void Update()
   {
       if (leverActivate && Input.GetKeyDown(KeyCode.F)){
        Interact();
        Debug.Log("Tombol dipencet");
        
       }

      
   }
   public void Interact(){

    
    gateOpen.Invoke();
    Debug.Log("Gerbang dibuka");
       SoundManager.PlaySound(SoundType.GateAndLever);
    }
    
      


}



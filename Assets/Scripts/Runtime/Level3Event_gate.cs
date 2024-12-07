using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Level3Event_gate : MonoBehaviour
{
   
   [SerializeField] private GameObject uiTextPrompt;
   [SerializeField] private GameObject uiText;
   [SerializeField] private GameObject gerbang;
   [SerializeField] private bool tutup;

   
   

   public UnityEvent findLever;

   public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
        tutup = true;
        uiTextPrompt.SetActive(true);
        Debug.Log("Player Masuk");
       }
   }

   public void OnTriggerExit2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
        tutup = false;
        Debug.Log("Player Keluar");
        uiTextPrompt.SetActive(false);
        uiText.SetActive(false);
       }
   }

   /// <summary>
   /// Update is called every frame, if the MonoBehaviour is enabled.
   /// </summary>
   void Update()
   {
       if (tutup && Input.GetKeyDown(KeyCode.F)){
       
        Interact();
        Debug.Log("Tombol dipencet");
        
       }

      
   }
   public void Interact(){
    if(gerbang.transform.position.y < -3.0f){
        findLever.Invoke();
    }

   }

}

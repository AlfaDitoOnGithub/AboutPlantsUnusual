using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelFinish : MonoBehaviour
{
    // [SerializeField] private GameObject stageClearUI;
    public UnityEvent levelFinish;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
       {
        Debug.Log("Level Selesai");
        levelFinish.Invoke();
       }
    }

}

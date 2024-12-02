using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    public Slider healthBarSlider;
    public int maxHealth;
    public int currHealth;
    public HealthSystem UIPlayerHealth;
    [SerializeField] private HurtboxController _hc;

    
   
    void Awake()
    {   
        
        UIPlayerHealth = _hc.playerHealth;
        currHealth = UIPlayerHealth.GetCurrHealth();
        maxHealth = UIPlayerHealth.GetMaxHealth();

    }

    void Update()
    {
        currHealth = UIPlayerHealth.GetCurrHealth();
        healthBarSlider.value = currHealth;
        // healthBarSlider.maxValue = maxHealth;
    }

}

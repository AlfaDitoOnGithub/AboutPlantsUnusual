using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    [SerializeField] public Slider healthBarSlider;
    public int maxHealth;
    public int currHealth;
    public HealthSystem UIPlayerHealth;
    
    [SerializeField] private HurtboxController _hc;

    
   
    void Awake()
    {   
        UIPlayerHealth = new HealthSystem(10);
        currHealth = UIPlayerHealth.GetCurrHealth();
        maxHealth = UIPlayerHealth.GetMaxHealth();

    }

    void Start()
    {
        _hc.healthBarAdj += HealthBarAdjustment;
    }

    void Update()
    {
        // currHealth = UIPlayerHealth.GetCurrHealth();
        // healthBarSlider.value = currHealth;
        // healthBarSlider.maxValue = maxHealth;
    }

    private void HealthBarAdjustment(object sender, HurtboxController.healthArgs e){
        healthBarSlider.value = e.currHealth;
    }

}

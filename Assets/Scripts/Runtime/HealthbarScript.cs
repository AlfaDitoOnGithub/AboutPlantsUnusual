using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    public Slider healthBarSlider;
    public int maxHealth = 10;
    public int currHealth;

    private HurtboxController hero;
    
    // Start is called before the first frame update
    void Start()
    {   currHealth = hero.playerHealth.GetCurrHealth();
        maxHealth = hero.playerHealth.GetMaxHealth();

    }

    // Update is called once per frame
    void Update()
    {
        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;
    }
}

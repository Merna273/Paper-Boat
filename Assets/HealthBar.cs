using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;
    }
}

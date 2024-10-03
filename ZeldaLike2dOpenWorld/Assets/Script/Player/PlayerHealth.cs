using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float damageCooldown=2;
    public Text text;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth=maxHealth;
        healthBar.SetMaxHeath(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        damageCooldown-=Time.deltaTime;
    }

    public void TakeDamage(int _damage)
    {
        if(damageCooldown<=0){
            healthBar.SetHealth(currentHealth-=_damage);
            damageCooldown=2;
            text.text = currentHealth+"/"+maxHealth;
        }
    }
}

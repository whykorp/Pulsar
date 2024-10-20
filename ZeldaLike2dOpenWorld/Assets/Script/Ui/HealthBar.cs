using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
     public Slider slider;
     public Text textCurrentHealth;
     public Text textMaxHealth;

     public void SetMaxHeath(float _Maxhealth)
     {
        
          slider.maxValue = _Maxhealth;
          textMaxHealth.text =""+_Maxhealth;

     }

     public void SetHealth(float _health)
     {
        slider.value = _health;
        textCurrentHealth.text = _health + "/";
     }
}

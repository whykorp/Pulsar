using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public float showHealth;
    public Text playerNbHpText;
    public new Transform transform;
    public Rigidbody2D rb;
    public float xDir;
    public float yDir;

    public HealthBar healthBar;
    private Vector2 vector2;
    private Vector3 velocity=Vector3.zero;

    void Awake()
    {
        transform=GetComponent<Transform>();
        rb=GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        PlayerStats.playerCurrentHealth=PlayerStats.playerMaxHealth;
        healthBar.SetMaxHeath(PlayerStats.playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {


        showHealth =  PlayerStats.playerCurrentHealth;
    }

    public void TakeDamage(float _damage)
    {
         PlayerStats.playerCurrentHealth-=_damage;
        if(InFightMainMenu.inFight)
        {
            playerNbHpText.text=PlayerStats.playerCurrentHealth+"/"+PlayerStats.playerMaxHealth;
            healthBar.SetHealth(PlayerStats.playerCurrentHealth);
            
        }
    }
}

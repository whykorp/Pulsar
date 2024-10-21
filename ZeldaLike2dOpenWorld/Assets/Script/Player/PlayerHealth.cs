using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    static public float maxHealth = 200;
    static public float currentHealth;
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
        currentHealth=maxHealth;
        healthBar.SetMaxHeath(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth-=_damage;
        if(InFightMainMenu.inFight)
        {
            playerNbHpText.text=currentHealth+"/"+maxHealth;
            healthBar.SetHealth(currentHealth);
        }
    }
}

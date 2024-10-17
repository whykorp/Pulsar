using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float damageMaxCooldown; 
    private float damageCooldown=0;
    public Text text;
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
        damageCooldown-=Time.deltaTime;
    }

    public void TakeDamage(Transform _collision, float _knockbackForce, bool _knockBack=false)
    {
        if(damageCooldown<=0){
            
            damageCooldown=damageMaxCooldown;
            text.text = currentHealth+"/"+maxHealth;
            if(_knockBack==true)
            {
                xDir=(_collision.position.x-transform.position.x)*_knockbackForce;
                yDir=(_collision.position.y-transform.position.y)*_knockbackForce;
                Debug.Log("xDir:"+xDir);
                Debug.Log("yDir:"+yDir);
                
                rb.AddForce(new Vector2(xDir, yDir), ForceMode2D.Impulse);
                
                
            }
        }
    }
}

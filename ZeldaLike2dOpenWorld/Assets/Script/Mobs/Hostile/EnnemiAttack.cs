using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 20;
    public new Transform transform;
    public GameObject enemyGraphics;
    public float knockbackForce;

    void Awake()
    {
        transform=enemyGraphics.GetComponent<Transform>();
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(transform, knockbackForce, true);
            Debug.Log("Fight !");
        }
    }
}

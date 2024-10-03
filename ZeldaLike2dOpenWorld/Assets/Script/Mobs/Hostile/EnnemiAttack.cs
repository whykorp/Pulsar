using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 20;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(20);
        }
    }
}

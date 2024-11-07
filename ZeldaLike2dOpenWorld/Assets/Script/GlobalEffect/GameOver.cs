using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static void PlayerDeath()
    {
        PlayerHealth.currentHealth=PlayerHealth.maxHealth;
        Debug.Log("You are Dead");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static void PlayerDeath()
    {
       PlayerStats.playerCurrentHealth=PlayerStats.playerMaxHealth;
        Debug.Log("You are Dead");
    }
}

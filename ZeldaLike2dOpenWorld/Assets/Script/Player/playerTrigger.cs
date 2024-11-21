using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public InFightMainMenu inFightMainMenu;
    public InFightEnemyData Goombatreox;
    static public GameObject enemyInFight;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Goombatreox"))
        {
            enemyInFight=collision.gameObject;
            inFightMainMenu.StartFight(Goombatreox, Random.Range(1,10));
        }
    }
}
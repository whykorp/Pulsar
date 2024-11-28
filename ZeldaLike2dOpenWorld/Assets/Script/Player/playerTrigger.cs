using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public InFightMainMenu inFightMainMenu;
    public InFightEnemyData[] enemyList;
    static public GameObject enemyInFight;
    public int difficulty = 3;
    public int facility = 3;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Goombatreox"))
        {
            enemyInFight=collision.gameObject;
            inFightMainMenu.StartFight(enemyList[0], Random.Range(Mathf.Max(PlayerStats.playerLvl-facility,1),PlayerStats.playerLvl+difficulty));
        }
    } 

    void Update(){
        if(Input.GetKeyDown(KeyCode.N)){
            inFightMainMenu.StartFight(enemyList[1], Random.Range(Mathf.Max(PlayerStats.playerLvl-facility,1),PlayerStats.playerLvl+difficulty));
        }
    }
}
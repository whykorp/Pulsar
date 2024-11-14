using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrigger : MonoBehaviour
{
    public InFightMainMenu inFightMainMenu;
    public InFightEnemyData Goombatreox;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goombatreox"))
        {
            inFightMainMenu.StartFight(Goombatreox, 1);
        }
    }
}

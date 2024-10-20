using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFightPlayerAction : MonoBehaviour
{
    public FightManager fightManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&FightManager.isPlayerTurn==true)
        {
            BaseAttack(30);
        }
    }

    void BaseAttack(int _damage)
    {
        fightManager.EnemyTakeDamage(_damage);
        Debug.Log("player had attacked");
        FightManager.playerAction="Kriss utilise attaque de base";
        FightManager.isPlayerTurn=false;
    }
}

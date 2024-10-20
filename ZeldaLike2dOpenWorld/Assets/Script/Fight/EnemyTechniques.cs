using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTechniques : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public void BaseEnemyAttack(InFightEnemyData _inFightEnemyData)
    {
        playerHealth.TakeDamage(20);
        FightManager.enemyAction=_inFightEnemyData.enemyName+" utilise frappe";
    }
}

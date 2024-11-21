using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTechniques : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public void BaseEnemyAttack(InFightEnemyData _inFightEnemyData,float currentEnemyAttack)
    {
        playerHealth.TakeDamage(40/PlayerStats.playerCurrentDefense*currentEnemyAttack);
        FightManager.enemyAction=_inFightEnemyData.enemyName+" utilise frappe";
    }
    
}

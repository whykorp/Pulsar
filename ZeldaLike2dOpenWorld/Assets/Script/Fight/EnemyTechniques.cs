using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTechniques : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public DotManager dotManager;
    public void BaseEnemyAttack(InFightEnemyData _inFightEnemyData,float currentEnemyAttack)
    {
        playerHealth.TakeDamage(40/PlayerStats.playerCurrentDefense*currentEnemyAttack);
        FightManager.enemyAction=_inFightEnemyData.enemyName+" utilise frappe";
    }

    public void Branling(InFightEnemyData _inFightEnemyData,float currentEnemyAttack)
    {
        FightManager.enemyCurrentDefense += 0.1f;
        FightManager.enemyAction=_inFightEnemyData.enemyName+" se branle et augmente sa défense";
    }

    public void AtomicProut(InFightEnemyData _inFightEnemyData, float currentEnemyAttack)
    {
        Debug.Log($"current enemy attack: {currentEnemyAttack}");
        playerHealth.TakeDamage(20/PlayerStats.playerCurrentDefense*currentEnemyAttack);
        dotManager.ApplyDOT("proutPoison",10f*currentEnemyAttack,5);
        FightManager.enemyAction=_inFightEnemyData.enemyName+" utilise AtomicProut";
    }

    
}

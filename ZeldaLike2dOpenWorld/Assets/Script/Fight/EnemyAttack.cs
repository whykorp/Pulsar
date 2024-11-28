using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    int techniquesUtilised;
    public EnemyTechniques enemyTechniques;
    public HealthBar playerHealthBar;

    
    
    
    public void EnnemyTurn(InFightEnemyData _inFightEnemyData,float _currentEnemyAttack)
    {
        switch(_inFightEnemyData.mind)
        {
            case 0:
            

                techniquesUtilised=Random.Range(0,_inFightEnemyData.techniques.Length-1);
                switch(_inFightEnemyData.techniques[techniquesUtilised])
                {
                    case 0:
                        enemyTechniques.BaseEnemyAttack(_inFightEnemyData, _currentEnemyAttack);
                        break;

                    case 1:
                        enemyTechniques.Branling(_inFightEnemyData, _currentEnemyAttack);
                        break;

                    case 2:
                        enemyTechniques.AtomicProut(_inFightEnemyData, _currentEnemyAttack);
                        break;
                    
                }
                break;


            
                
        }

        if(PlayerStats.playerCurrentHealth<0)
        {
            PlayerStats.playerCurrentHealth=0;
            playerHealthBar.SetHealth(PlayerStats.playerCurrentHealth);
            Debug.Log("set player health to 0");
        }
    }
}

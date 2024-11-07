using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    int techniquesUtilised;
    public EnemyTechniques enemyTechniques;
    public HealthBar playerHealthBar;

    
    
    
    public void EnnemyTurn(InFightEnemyData _inFightEnemyData)
    {
        switch(_inFightEnemyData.mind)
        {
            case 0:
            

                techniquesUtilised=Random.Range(0,_inFightEnemyData.techniques.Length-1);
                switch(_inFightEnemyData.techniques[techniquesUtilised])
                {
                    case 0:
                        enemyTechniques.BaseEnemyAttack(_inFightEnemyData);
                        break;


                    
                }
                break;

            
                
        }

        if(PlayerHealth.currentHealth<0)
        {
            PlayerHealth.currentHealth=0;
            playerHealthBar.SetHealth(PlayerHealth.currentHealth);
            Debug.Log("set player health to 0");
        }
    }
}

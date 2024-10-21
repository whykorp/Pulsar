using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFightPlayerAction : MonoBehaviour
{
    public FightManager fightManager;
    public HealthBar enemyHealthBar;
    public HealthBar playerHealthBar;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&FightManager.isPlayerTurn==true)
        {
            SimpleAttack();
        }
    }


    //SQL:
    //Module 1:
    //PlayerStats.currentPlayerAttack,InFightMainMenu.enemyCurrentDefense
    void SimpleAttack()
    {
        FightManager.enemyCurrentHealth-=20*PlayerStats.currentPlayerAttack*PlayerStats.attackCoeficien/FightManager.enemyCurrentDefense/PlayerStats.defenseCoeficien;
        Debug.Log(FightManager.enemyCurrentHealth);
        enemyHealthBar.SetHealth(FightManager.enemyCurrentHealth);
        FightManager.playerAction="Kriss utilise Simple_Attack()";
        FightManager.isPlayerTurn=false;
    }

    void PowerAttack()
    {
        float rand = Random.Range(0f, 1f);
        if(rand > 0.49f)  // 70% chance to succeed
        {
            FightManager.enemyCurrentHealth -= 50 * PlayerStats.currentPlayerAttack * PlayerStats.attackCoeficien / FightManager.enemyCurrentDefense / PlayerStats.defenseCoeficien;
            Debug.Log("Power_Attack successful! Enemy Health: " + FightManager.enemyCurrentHealth);
            enemyHealthBar.SetHealth(FightManager.enemyCurrentHealth);
            FightManager.playerAction = "Kriss utilise Power_Attack()";
        }
        else
        {
            Debug.Log("Power_Attack failed!");
            FightManager.playerAction = "Kriss a échoué Power_Attack()";
        }
        FightManager.isPlayerTurn = false;
    }

    // Healing Query to restore player health
    void HealingQuery()
    {
        float healAmount = 0.25f * PlayerHealth.maxHealth;
        PlayerHealth.currentHealth = Mathf.Min(PlayerHealth.maxHealth, PlayerHealth.currentHealth + healAmount);
        Debug.Log("Healing_Query successful! Player Health: " + PlayerHealth.currentHealth);
        playerHealthBar.SetHealth(PlayerHealth.currentHealth);
        FightManager.playerAction = "Kriss utilise Healing_Query()";
        FightManager.isPlayerTurn = false;
    }
    
}

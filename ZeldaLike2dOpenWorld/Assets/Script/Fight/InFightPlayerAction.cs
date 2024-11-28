using System;
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
        if(Input.GetKeyDown(KeyCode.T)&&FightManager.isPlayerTurn==true)
        {
            PowerAttack();
        }
        if(Input.GetKeyDown(KeyCode.Y)&&FightManager.isPlayerTurn==true)
        {
            HealingQuery();
        }
        if(Input.GetKeyDown(KeyCode.U)&&FightManager.isPlayerTurn==true)
        {
            SynergisticBuff();
        }
        if(Input.GetKeyDown(KeyCode.I)&&FightManager.isPlayerTurn==true)
        {
            FirewallUpgrade();
        }
    }

    void CreateBuff(string _buffType, string _buffName, BuffManager.Buff _buff)
    {
        FightManager.activeBuffs.Add(_buffName, _buff);
        if(_buffType=="attack")
        {
            PlayerStats.playerCurrentAttack *= _buff.value;  // Applique le buff immédiatement
        }
        else if(_buffType=="defense")
        {
            PlayerStats.playerCurrentDefense *= _buff.value;  // Applique le buff immédiatement
        }

        Debug.Log("Buff "+ _buff.type+ " appliqué ! "+_buff.value+" % "+_buffType+" pour " +(_buff.duration-1)+ " tours.");
    }


    //SQL:
    //Module 1:
    //PlayerStats.playerCurrentAttack,InFightMainMenu.enemyCurrentDefense
    public void SimpleAttack()
    {
        FightManager.enemyCurrentHealth-=100*PlayerStats.playerCurrentAttack*PlayerStats.playerAttackCoeficien/FightManager.enemyCurrentDefense;
        Debug.Log(FightManager.enemyCurrentHealth);
        enemyHealthBar.SetHealth(FightManager.enemyCurrentHealth);
        FightManager.playerAction="Kriss utilise Simple_Attack()";
        FightManager.isPlayerTurn=false;
    }

    public void PowerAttack()
    {
        float rand = UnityEngine.Random.Range(0f, 1f);
        if(rand > 0.49f)  // 50% chance to succeed
        {
            FightManager.enemyCurrentHealth -= 50 * PlayerStats.playerCurrentAttack * PlayerStats.playerAttackCoeficien / FightManager.enemyCurrentDefense;
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
    public void HealingQuery()
    {
        float healAmount = 0.25f * PlayerStats.playerMaxHealth;
        PlayerStats.playerCurrentHealth = Mathf.Min(PlayerStats.playerMaxHealth,PlayerStats.playerCurrentHealth + healAmount);
        Debug.Log("Healing_Query successful! Player Health: " +PlayerStats.playerCurrentHealth);
        playerHealthBar.SetHealth(PlayerStats.playerCurrentHealth);
        FightManager.playerAction = "Kriss utilise Healing_Query()";
        FightManager.isPlayerTurn = false;
    }

    public void SynergisticBuff()
    {
        BuffManager.Buff SynergisticBuff = new BuffManager.Buff("SynergisticBuff", 1.5f, 3+1);  // +50% attaque pour 3 tours
        CreateBuff("attack","SynergisticBuff", SynergisticBuff);
        FightManager.playerAction = "Kriss utilise Synergistic Buff";
        FightManager.isPlayerTurn = false;
    }

    public void FirewallUpgrade()
    {
        BuffManager.Buff FirewallUpgrade = new BuffManager.Buff("FirewallUpgrade", 1.5f, 3+1);  // +50% de défense pour 3 tours
        CreateBuff("defense","FirewallUpgrade", FirewallUpgrade);
        FightManager.playerAction = "Kriss utilise Firewall Upgrade";
        FightManager.isPlayerTurn = false;
    }
    
}

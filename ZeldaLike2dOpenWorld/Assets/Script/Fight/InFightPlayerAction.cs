using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class InFightPlayerAction : MonoBehaviour
{
    public FightManager fightManager;
    public HealthBar enemyHealthBar;
    public HealthBar playerHealthBar;
    public GameObject inputField;
    public Text inputFieldResult;
    public Text inputFieldPlaceholder;
    public string inputFieldContent;
    public float typingTimer;
    public float typingDuration;
    bool isEnterPressed;
    bool isGoodLineEnter;
    public float critDificulty=5;

    void Awake()
    {
        inputField.SetActive(false);
    }

    void Update()
    {
        typingTimer+=0.01666666666f;
        isEnterPressed=Input.GetKeyDown(KeyCode.Return);
        
    }
    public IEnumerator GetPlayerCommandLine(string commandLineToType)
    {
        Debug.Log("démarééé");
        Debug.Log(commandLineToType);
        inputField.SetActive(true);
        inputFieldPlaceholder.text=commandLineToType;
        
        typingTimer=0;
        yield return new WaitUntil(()=>isEnterPressed==true);
        typingDuration=typingTimer;
        if(inputFieldResult.text==commandLineToType)
        {
            isGoodLineEnter=true;
        }
        else
        {
            isGoodLineEnter=false;
        }
        inputField.GetComponent<InputField>().text="";
        inputField.SetActive(false);
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
        else if(_buffType=="enemyAttack")
        {
            FightManager.enemyCurrentAttack *= _buff.value;  // Applique le buff immédiatement
        }
        else if(_buffType=="enemyDefense")
        {
            FightManager.enemyCurrentDefense *= _buff.value;  // Applique le buff immédiatement
        }

        Debug.Log("Buff "+ _buff.type+ " appliqué ! "+_buff.value+" % "+_buffType+" pour " +(_buff.duration-1)+ " tours.");
    }


    //SQL:
    //Module 1:
    //PlayerStats.playerCurrentAttack,InFightMainMenu.enemyCurrentDefense
    public IEnumerator SQLinjection()
    {
        Debug.Log("coroutine started");
        StartCoroutine(GetPlayerCommandLine("OR IF 1=1 THEN PASS"));
        yield return new WaitUntil(()=>isEnterPressed);
        if(isGoodLineEnter)
        {
            if(typingDuration<critDificulty)
            {
                FightManager.enemyCurrentHealth-=45*PlayerStats.playerCurrentAttack*PlayerStats.playerAttackCoeficien/FightManager.enemyCurrentDefense;
                FightManager.playerAction="L'injection SQL est un succès, coup critique!";
            }
            else
            {
                FightManager.enemyCurrentHealth-=30*PlayerStats.playerCurrentAttack*PlayerStats.playerAttackCoeficien/FightManager.enemyCurrentDefense;
                FightManager.playerAction="L'injection SQL est un succès!";
            }
            //Debug.Log(FightManager.enemyCurrentHealth);
            enemyHealthBar.SetHealth(FightManager.enemyCurrentHealth);
            
            FightManager.isPlayerTurn=false;
        }
        else
        {
            FightManager.playerAction="L'injection SQL a échoué";
            FightManager.isPlayerTurn=false;
        }
        
    }

    public IEnumerator DeleteDatabase()
    {
        StartCoroutine(GetPlayerCommandLine("FROM DATABASE DROP *"));
        yield return new WaitUntil(()=>isEnterPressed);
        if(isGoodLineEnter)
        {
            float rand = UnityEngine.Random.Range(0f, 1f);
            if(rand > 0.49f)  // 50% chance to succeed
            {
                if(typingDuration<critDificulty)
                {
                    FightManager.enemyCurrentHealth -= 100 * PlayerStats.playerCurrentAttack * PlayerStats.playerAttackCoeficien / FightManager.enemyCurrentDefense;
                    FightManager.playerAction = "La base de données a été supprimée, coup critique!";
                }
                else
                {
                    FightManager.enemyCurrentHealth -= 75 * PlayerStats.playerCurrentAttack * PlayerStats.playerAttackCoeficien / FightManager.enemyCurrentDefense;
                    FightManager.playerAction = "la base de données a été supprimée!";
                }
                
                Debug.Log("Power_Attack successful! Enemy Health: " + FightManager.enemyCurrentHealth);
                enemyHealthBar.SetHealth(FightManager.enemyCurrentHealth);
                
            }
            else
            {
                Debug.Log("Power_Attack failed!");
                FightManager.playerAction = "ERROR 1045 (28000): Access denied for user 'Kriss'@'Pulsar' (using password: YES)";
            }
            FightManager.isPlayerTurn = false;
        }
        else
        {
            FightManager.playerAction="Echec de la suppression de la base de données";
            FightManager.isPlayerTurn=false;
        }
        
    }

    // Healing Query to restore player health
    public IEnumerator HealingQuery()
    {
        StartCoroutine(GetPlayerCommandLine("SET hp = hp + 25%"));
        yield return new WaitUntil(()=>isEnterPressed);
        if(isGoodLineEnter)
        {
            if(typingDuration<critDificulty)
            {
                float healAmount = 0.40f * PlayerStats.playerMaxHealth;
                PlayerStats.playerCurrentHealth = Mathf.Min(PlayerStats.playerMaxHealth,PlayerStats.playerCurrentHealth + healAmount);
                FightManager.playerAction = "La requête de soin a réussi, coup critique!";
            }
            else
            {
                float healAmount = 0.25f * PlayerStats.playerMaxHealth;
                PlayerStats.playerCurrentHealth = Mathf.Min(PlayerStats.playerMaxHealth,PlayerStats.playerCurrentHealth + healAmount);
                FightManager.playerAction = "La requête de soin a réussi!";
            }
            
            playerHealthBar.SetHealth(PlayerStats.playerCurrentHealth);
            FightManager.isPlayerTurn = false;
        }
        else
        {
            FightManager.playerAction="La requête de soin a échoué";
            FightManager.isPlayerTurn=false;
        }
        
    }

    public IEnumerator Overload()
    {
        StartCoroutine(GetPlayerCommandLine("OVERLOAD"));
        yield return new WaitUntil(()=>isEnterPressed);
        if(isGoodLineEnter)
        {
            if(typingDuration<critDificulty)
            {
                BuffManager.Buff OverloadEnemyNerfcrit = new BuffManager.Buff("OverloadEnemyNerfcrit", 0.5f, 3+1);  // +50% attaque pour 3 tours
                CreateBuff("enemyAttack","OverloadEnemyNerfcrit", OverloadEnemyNerfcrit);
                FightManager.playerAction = "Kriss utilise Overload, coup critique!";
            }
            else
            {
                BuffManager.Buff OverloadEnemyNerf = new BuffManager.Buff("OverloadEnemyNerf", 0.3f, 3+1);  // +50% attaque pour 3 tours
                CreateBuff("enemyAttack","OverloadEnemyNerf", OverloadEnemyNerf);
                FightManager.playerAction = "Kriss utilise Overload";
            }
            FightManager.isPlayerTurn = false;
        }
        else
        {
            FightManager.playerAction="L'overload a échoué";
            FightManager.isPlayerTurn=false;
        }
        
    }

    public void FirewallUpgrade()
    {
        BuffManager.Buff FirewallUpgrade = new BuffManager.Buff("FirewallUpgrade", 1.5f, 3+1);  // +50% de défense pour 3 tours
        CreateBuff("defense","FirewallUpgrade", FirewallUpgrade);
        FightManager.playerAction = "Kriss utilise Firewall Upgrade";
        FightManager.isPlayerTurn = false;
    }


    //SQL:
    //Module 2:
    
    
}

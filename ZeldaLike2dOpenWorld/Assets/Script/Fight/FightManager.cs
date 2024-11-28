using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    // Références des objets dans la scène
    public GameObject announcerFont;       // Le fond de texte pour les annonces de combat
    public GameObject announcerText;       // Le texte des annonces de combat
    public GameObject modulePanelUI;
    public GameObject attackPanelUI;
    public InFightMainMenu inFightMainMenu; // Référence au menu principal du combat
    public EnemyAttack enemyAttack;        // Comportement de l'ennemi
    public PlayerHealth playerHealth;      // Comportement de la santé du joueur
    public AttackButton attackButton;

    // Références aux barres de vie
    public HealthBar enemyHealthBar;       // Barre de vie de l'ennemi
    public HealthBar playerHealthBar;      // Barre de vie du joueur

    public Text enemyAttackDevText;
    public Text enemyDefenseDevText;
    public Text enemyHpDevText;
    public Text playerAttackDevText;
    public Text playerDefenseDevText;
    public Text playerHpDevText;

    // Variables statiques qui conservent les informations de combat
    public static bool isPlayerTurn = false;   // Indique si c'est au tour du joueur
    public static string playerAction = "";    // Action actuelle du joueur
    public static string enemyAction = "";     // Action actuelle de l'ennemi

    // Stats de l'ennemi (modifiées pendant le combat)
    public static float enemyCurrentHealth;
    public static float enemyCurrentAttack;
    public static float enemyCurrentDefense;

    public float statsPerLvlCoeficien;

    public static Dictionary<string, BuffManager.Buff> activeBuffs = new Dictionary<string, BuffManager.Buff>();
    public static List<DotManager.DOT> activeDOTs = new List<DotManager.DOT>();


    public PlayerLeveling playerLeveling;


    // Méthode appelée au réveil du script
    void Awake()
    {
        // Désactiver le texte d'annonce tant qu'il n'est pas utilisé
        announcerFont.SetActive(false);
        announcerText.SetActive(false);
    }

    void Update()
    {
        enemyAttackDevText.text= "Atk:"+enemyCurrentAttack;
        enemyDefenseDevText.text= "Def:"+enemyCurrentDefense;
        enemyHpDevText.text= "Hp:"+enemyCurrentHealth;
        playerAttackDevText.text = "Atk:"+PlayerStats.playerCurrentAttack;
        playerDefenseDevText.text = "Def:"+PlayerStats.playerCurrentDefense;
        playerHpDevText.text = "Hp:"+PlayerStats.playerCurrentHealth;
    }

    // Méthode pour réinitialiser les stats de l'ennemi au début du combat
    public static void ResetEnemyStats(InFightEnemyData _inFightEnemyData, int _lvl, float _statsPerLvlCoeficien)
    {
        enemyCurrentHealth = _inFightEnemyData.baseHp*(1+((_lvl-1)*_statsPerLvlCoeficien));     // Santé de base de l'ennemi
        Debug.Log(_inFightEnemyData.baseHp+"*"+_lvl+"*"+_statsPerLvlCoeficien);
        enemyCurrentAttack = _inFightEnemyData.baseAttack*(1+((_lvl-1)*_statsPerLvlCoeficien)); // Attaque de base de l'ennemi
        Debug.Log(_inFightEnemyData.baseAttack+"*"+_lvl+"*"+_statsPerLvlCoeficien);
        enemyCurrentDefense = _inFightEnemyData.baseDef*(1+((_lvl-1)*_statsPerLvlCoeficien));   // Défense de base de l'ennemi
        Debug.Log(_inFightEnemyData.baseDef+"*"+_lvl+"*"+_statsPerLvlCoeficien);
    }

    // Méthode pour réinitialiser les stats du joueur au début du combat
    public static void ResetPlayerStats()
    {
        PlayerStats.playerCurrentAttack = PlayerStats.playerBaseAttack;     // Attaque de base du joueur
        PlayerStats.playerCurrentDefense = PlayerStats.playerBaseDefense;   // Défense de base du joueur
        PlayerStats.playerCurrentAccuracy = PlayerStats.playerBaseAccuracy; // Précision de base du joueur
    }

    public void UpdateBuffs()
    {
        List<string> buffsToRemove = new List<string>();

        // Parcourir tous les buffs actifs
        foreach (KeyValuePair<string, BuffManager.Buff> buff in activeBuffs)
        {
            buff.Value.duration--;

            // Vérifie si le buff expire
            if (buff.Value.duration <= 0)
            {
                buffsToRemove.Add(buff.Key);
                RemoveBuffEffect(buff.Key);
            }
        }

        // Supprimer les buffs expirés
        foreach (string buffKey in buffsToRemove)
        {
            activeBuffs.Remove(buffKey);
        }
    }

    public void UpdateDOTs()
    {
        List<DotManager.DOT> expiredDOTs = new List<DotManager.DOT>();

        foreach (DotManager.DOT dot in activeDOTs)
        {
             // Applique les dégâts du DOT
            enemyCurrentHealth -= dot.damagePerTurn;
            Debug.Log($"DOT {dot.name} inflige {dot.damagePerTurn} dégâts. Tours restants : {dot.remainingTurns}");

            // Réduit la durée du DOT
            dot.remainingTurns--;

            // Si le DOT n'a plus de tours restants, marque-le pour suppression
            if (dot.remainingTurns <= 0)
            {
            expiredDOTs.Add(dot);
            }
        }

        // Supprime les DOT expirés
        foreach (DotManager.DOT expired in expiredDOTs)
        {
            activeDOTs.Remove(expired);
            Debug.Log($"DOT {expired.name} a expiré.");
        }
    }


    public void RemoveBuffEffect(string buffType)
    {
        // En fonction du type de buff, on réinitialise les stats du joueur
        if (buffType == "attack")
        {
            PlayerStats.playerAttackCoeficien /= 1.15f;  // Annule l'augmentation d'attaque
            Debug.Log("Buff d'attaque expire");
        }
        else if (buffType == "defense")
        {
            PlayerStats.playerDefenseCoeficien /= 1.2f;  // Annule l'augmentation de défense
            Debug.Log("Buff de défense expire");
        }
        else if (buffType == "SynergisticBuff")
        {
            PlayerStats.playerCurrentAttack /= 1.5f;  // Annule l'augmentation du SynergisticBuff
            Debug.Log("Synergistic Buff expire");
        }
        else if (buffType == "FirewallUpgrade")
        {
            PlayerStats.playerCurrentDefense /= 1.5f;  // Annule l'augmentation du SynergisticBuff
            Debug.Log("Firewall Upgrade expire");
        }
        // Ajouter d'autres types de buff ici...
    }

    // Coroutine pour gérer le déroulement du combat
    public IEnumerator FightAnnouncer(InFightEnemyData _inFightEnemyData,int _enemyLvl)
    {
        ResetEnemyStats(_inFightEnemyData, _enemyLvl, statsPerLvlCoeficien);
        ResetPlayerStats();
        // Initialisation des barres de vie
        enemyHealthBar.SetMaxHeath(enemyCurrentHealth);          // Santé maximale de l'ennemi
        Debug.Log(enemyCurrentHealth);
        enemyHealthBar.SetHealth(enemyCurrentHealth);            // Santé actuelle de l'ennemi
        playerHealthBar.SetMaxHeath(PlayerStats.playerMaxHealth);           // Santé maximale du joueur
        Debug.Log(PlayerStats.playerMaxHealth);
        playerHealthBar.SetHealth(PlayerStats.playerCurrentHealth);         // Santé actuelle du joueur
        

        // Affichage du texte d'annonce
        announcerFont.SetActive(true);
        announcerText.SetActive(true);
        announcerText.GetComponent<Text>().text = "Vous avez rencontré un " + _inFightEnemyData.enemyName + " ennemi...";

        // Pause de 1 seconde avant de commencer le combat
        yield return new WaitForSecondsRealtime(1);
        yield return new WaitUntil(() => Input.anyKeyDown); // Attente d'une entrée clavier pour commencer

        // Boucle principale du combat (basée sur la santé réelle du joueur et de l'ennemi)
        while (enemyCurrentHealth > 0 && PlayerStats.playerCurrentHealth > 0)
        {
            // Tour du joueur
            announcerText.GetComponent<Text>().text = "C'est a Kriss d'agir";
            // Juste avant l'action du joueur
            UpdateDOTs();
            yield return new WaitForSecondsRealtime(1);
            isPlayerTurn = true; // Le joueur peut agir

            // Attente que le joueur effectue une action
            yield return new WaitUntil(() => playerAction != "");
            attackButton.ResetPanel();
            announcerText.GetComponent<Text>().text = playerAction;   // Afficher l'action du joueur
            playerAction = ""; // Réinitialiser l'action du joueur
            UpdateBuffs();
            // Vérification de la santé de l'ennemi après l'action du joueur
            if (enemyCurrentHealth <= 0)
            {
                announcerText.GetComponent<Text>().text = "Vous avez vaincu " + _inFightEnemyData.enemyName + " ennemi";
                playerWin(_inFightEnemyData, _enemyLvl);
                break;  // Fin du combat si l'ennemi est vaincu
            }

            // Pause avant le tour de l'ennemi
            yield return new WaitForSecondsRealtime(2);
            announcerText.GetComponent<Text>().text = "C'est au tour de l'ennemi d'agir";
            yield return new WaitForSecondsRealtime(2);

            // Tour de l'ennemi
            enemyAttack.EnnemyTurn(_inFightEnemyData, enemyCurrentAttack);    // L'ennemi effectue une action
            yield return new WaitUntil(() => enemyAction != "");   // Attente de l'action de l'ennemi
            announcerText.GetComponent<Text>().text = enemyAction; // Afficher l'action de l'ennemi
            enemyAction = "";  // Réinitialiser l'action de l'ennemi

            // Vérification de la santé du joueur après le tour de l'ennemi
            if (PlayerStats.playerCurrentHealth == 0)
            {
                announcerText.GetComponent<Text>().text = "An ally as been slain";
                break;  // Fin du combat si le joueur est vaincu
            }

            // Pause avant de recommencer la boucle
            yield return new WaitForSecondsRealtime(2);
        }

        // Fin du combat : donner l'expérience, items, etc.
        Debug.Log("Combat termine");
        yield return new WaitForSecondsRealtime(2);

        // Quitter l'écran de combat
        if(PlayerStats.playerCurrentHealth==0)
        {
            GameOver.PlayerDeath();
        }
        inFightMainMenu.QuitFight();
    }

    public void playerWin(InFightEnemyData _inFightEnemyData, int _enemyLvl)
    {
        Destroy(PlayerTrigger.enemyInFight);
        float coef=Math.Max(1+((_enemyLvl-PlayerStats.playerLvl)/10*PlayerStats.playerXpGivedCoef),1);
        playerLeveling.GiveXp(_inFightEnemyData.xpGivedAtDead*coef);
    }

    public void LeakCaller()
    {
        if(isPlayerTurn==true)
        {
            StartCoroutine(Leak());
        }
    }
    public IEnumerator Leak()
    {
        announcerText.GetComponent<Text>().text = "Kriss fuis le combat...";
        yield return new WaitForSecondsRealtime(1.5f);
        inFightMainMenu.QuitFight();
        Destroy(PlayerTrigger.enemyInFight);
    }
}

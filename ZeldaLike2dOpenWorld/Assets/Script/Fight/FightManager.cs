using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    // Références des objets dans la scène
    public GameObject announcerFont;       // Le fond de texte pour les annonces de combat
    public GameObject announcerText;       // Le texte des annonces de combat
    public InFightMainMenu inFightMainMenu; // Référence au menu principal du combat
    public EnemyAttack enemyAttack;        // Comportement de l'ennemi
    public PlayerHealth playerHealth;      // Comportement de la santé du joueur

    // Références aux barres de vie
    public HealthBar enemyHealthBar;       // Barre de vie de l'ennemi
    public HealthBar playerHealthBar;      // Barre de vie du joueur

    // Variables statiques qui conservent les informations de combat
    public static bool isPlayerTurn = false;   // Indique si c'est au tour du joueur
    public static string playerAction = "";    // Action actuelle du joueur
    public static string enemyAction = "";     // Action actuelle de l'ennemi

    // Stats de l'ennemi (modifiées pendant le combat)
    public static float enemyCurrentHealth;
    public static float enemyCurrentAttack;
    public static float enemyCurrentDefense;

    public static Dictionary<string, BuffManager.Buff> activeBuffs = new Dictionary<string, BuffManager.Buff>();


    // Méthode appelée au réveil du script
    void Awake()
    {
        // Désactiver le texte d'annonce tant qu'il n'est pas utilisé
        announcerFont.SetActive(false);
        announcerText.SetActive(false);
    }

    // Méthode pour réinitialiser les stats de l'ennemi au début du combat
    public static void ResetEnemyStats(InFightEnemyData _inFightEnemyData)
    {
        enemyCurrentHealth = _inFightEnemyData.baseHp;     // Santé de base de l'ennemi
        enemyCurrentAttack = _inFightEnemyData.baseAttack; // Attaque de base de l'ennemi
        enemyCurrentDefense = _inFightEnemyData.baseDef;   // Défense de base de l'ennemi
    }

    // Méthode pour réinitialiser les stats du joueur au début du combat
    public static void ResetPlayerStats()
    {
        PlayerStats.playerCurrentAttack = PlayerStats.playerBaseAttack;     // Attaque de base du joueur
        PlayerStats.playerCurrentDefense = PlayerStats.playerBaseDefense;   // Défense de base du joueur
        PlayerStats.playerCurrentAccuracy = PlayerStats.playerBaseAccuracy; // Précision de base du joueur
    }

    void UpdateBuffs()
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

    void RemoveBuffEffect(string buffType)
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
    public IEnumerator FightAnnouncer(InFightEnemyData _inFightEnemyData)
    {
        // Initialisation des barres de vie
        enemyHealthBar.SetMaxHeath(_inFightEnemyData.baseHp);          // Santé maximale de l'ennemi
        enemyHealthBar.SetHealth(_inFightEnemyData.baseHp);            // Santé actuelle de l'ennemi
        playerHealthBar.SetMaxHeath(PlayerStats.playerMaxHealth);           // Santé maximale du joueur
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
            isPlayerTurn = true; // Le joueur peut agir

            // Attente que le joueur effectue une action
            yield return new WaitUntil(() => playerAction != "");
            announcerText.GetComponent<Text>().text = playerAction;   // Afficher l'action du joueur
            playerAction = ""; // Réinitialiser l'action du joueur
            UpdateBuffs();
            // Vérification de la santé de l'ennemi après l'action du joueur
            if (enemyCurrentHealth <= 0)
            {
                announcerText.GetComponent<Text>().text = "Vous avez vaincu " + _inFightEnemyData.enemyName + " ennemi";
                break;  // Fin du combat si l'ennemi est vaincu
            }

            // Pause avant le tour de l'ennemi
            yield return new WaitForSecondsRealtime(3);
            announcerText.GetComponent<Text>().text = "C'est au tour de l'ennemi d'agir";
            yield return new WaitForSecondsRealtime(3);

            // Tour de l'ennemi
            enemyAttack.EnnemyTurn(_inFightEnemyData);    // L'ennemi effectue une action
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
            yield return new WaitForSecondsRealtime(3);
        }

        // Fin du combat : donner l'expérience, items, etc.
        Debug.Log("Combat termine");
        yield return new WaitForSecondsRealtime(3);

        // Quitter l'écran de combat
        if(PlayerStats.playerCurrentHealth==0)
        {
            GameOver.PlayerDeath();
        }
        inFightMainMenu.QuitFight();
    }
}

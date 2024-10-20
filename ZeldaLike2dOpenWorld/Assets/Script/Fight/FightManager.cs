using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public GameObject announcerFont;
    public GameObject announcerText;
    public InFightMainMenu inFightMainMenu;
    public EnemyAttack enemyAttack;
    public PlayerHealth playerHealth;
    public static bool isPlayerTurn=false;
    public HealthBar enemyHealthBar;
    public HealthBar playerHealthBar;
    public static string playerAction = "";
    public static string enemyAction = "";
    
    void Awake()
    {
        announcerFont.SetActive(false);
        announcerText.SetActive(false);
    }



    public IEnumerator FightAnnouncer(InFightEnemyData _inFightEnemyData)
    {
        enemyHealthBar.SetMaxHeath(_inFightEnemyData.baseHp);
        enemyHealthBar.SetHealth(_inFightEnemyData.baseHp);
        playerHealthBar.SetMaxHeath(playerHealth.maxHealth);
        playerHealthBar.SetHealth(playerHealth.currentHealth);
        announcerFont.SetActive(true);
        announcerText.SetActive(true);
        announcerText.GetComponent<Text>().text="Vous avez rencontre un "+_inFightEnemyData.enemyName+" ennemi...";
        Debug.Log("début de l'attente");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("fin de l'attente");
        yield return new WaitUntil(() => Input.anyKeyDown);
        Debug.Log("Key Pressed");
        while(enemyHealthBar.slider.value>0 && playerHealthBar.slider.value>0)
        {
            //On Doit attendre que le joueur fasse une action via les menus, la fonction appelée donne un valeur dépendant de l'action effectué à un variable, la fonction FightAnnouncer détécte le changement, fait l'annonce et apel le tour de l'ennemi puis annonce les résultat de l'action et recommence la boucle
            announcerText.GetComponent<Text>().text="C'est a Kriss d'agir";
            isPlayerTurn=true;
            yield return new WaitUntil(() => playerAction != "");
            announcerText.GetComponent<Text>().text=playerAction;
            playerAction="";

            if(InFightMainMenu.enemyCurrentHealthForThisFight<=0)
            {
                announcerText.GetComponent<Text>().text="Vous avez vaincu "+_inFightEnemyData.enemyName+" ennemi";
                break;
            }

            yield return new WaitForSecondsRealtime(3);
            announcerText.GetComponent<Text>().text="C'est au tour de l'enemi d'agir";
            yield return new WaitForSecondsRealtime(3);
            enemyAttack.EnnemyTurn(_inFightEnemyData);
            yield return new WaitUntil(() => enemyAction!="");
            announcerText.GetComponent<Text>().text=enemyAction;
            enemyAction="";
            yield return new WaitForSecondsRealtime(3);
            
            if(playerHealth.currentHealth<=0)
            {
                announcerText.GetComponent<Text>().text="An ally as been slained";
                break;
            }

        }
        //On affiche les résultats du combat, donne l'xp, les items etc...
        Debug.Log("Combat terminé");
        yield return new WaitForSecondsRealtime(3);
        inFightMainMenu.QuitFight();
    }

    public void EnemyTakeDamage(float _damage)
    {
        InFightMainMenu.enemyCurrentHealthForThisFight-=_damage;
        enemyHealthBar.SetHealth(InFightMainMenu.enemyCurrentHealthForThisFight);
    }
}

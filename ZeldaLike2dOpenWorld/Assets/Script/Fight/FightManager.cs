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
    public HealthBar enemyHealthBar;
    void Awake()
    {
        announcerFont.SetActive(false);
        announcerText.SetActive(false);
    }
    public void FightAnnouncer(InFightEnemyData _inFightEnemyData)
    {
        announcerFont.SetActive(true);
        announcerText.SetActive(true);
        announcerText.GetComponent<Text>().text="Vous avez rencontre un "+_inFightEnemyData.enemyName+" ennemi...";
        //On Doit rajouter le fait d'attendre une touche random préssée
        announcerFont.SetActive(false);
        announcerText.SetActive(false);
        //On lance une boucle qui se finit que quand un des participant à atteint 0 pv ou que le joueur à fuit.
            //On Doit attendre que le joueur fasse une action via les menus, la fonction appelée donne un valeur dépendant de l'action effectué à un variable, la fonction FightAnnouncer détécte le changement, fait l'annonce et apel le tour de l'ennemi puis annonce les résultat de l'action et recommence la boucle 
        //On affiche les résultats du combat, donne l'xp, les items etc...
        Debug.Log("Combat terminé");
        enemyHealthBar.SetMaxHeath(_inFightEnemyData.baseHp);
        enemyHealthBar.SetHealth(enemyHealthBar.slider.value-20, _inFightEnemyData.baseHp);
        //inFightMainMenu.QuitFight();
    }
}

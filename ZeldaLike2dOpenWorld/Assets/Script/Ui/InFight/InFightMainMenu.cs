using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InFightMainMenu : MonoBehaviour
{
    public static bool inFight = false;
    public GameObject inFightMainMenuUi;
    public GameObject inGameUi;
    
    public GameObject announcerFont;       // Le fond de texte pour les annonces de combat
    public GameObject announcerText;       // Le texte des annonces de combat
    public GameObject modulePanelUI;
    public GameObject attackPanelUI;

    public Text enemyNameText;
    public Text enemyHealthText;
    public Text enemyLvlText;
    public Text playerLvlText;
    public Image enemySpriteSlot;
    

    public FightManager fightManager;
    public AssignFightButton assignFightButton;
    public InFightEnemyData[] enemyList;
    
    
    

    void Awake()
    {
        inFightMainMenuUi.SetActive(false);
        announcerFont.SetActive(false);
        announcerText.SetActive(false);
        modulePanelUI.SetActive(false);
        modulePanelUI.SetActive(false);
    }
    void Update()
    {
        
    }

    public void StartFight(InFightEnemyData _inFightEnemyData, int _lvl)
    {
        inFightMainMenuUi.SetActive(true);
        inGameUi.SetActive(false);
        announcerFont.SetActive(true);
        announcerText.SetActive(true);
        modulePanelUI.SetActive(false);
        attackPanelUI.SetActive(false);
        Time.timeScale = 0;
        inFight = true;
        assignFightButton.UpdateModuleButton();
        enemyNameText.text=_inFightEnemyData.enemyName;
        enemyHealthText.text=_inFightEnemyData.baseHp+"/";
        playerLvlText.text="Lvl "+PlayerStats.playerLvl;
        enemyLvlText.text="Lvl "+_lvl;
        FightManager.enemyCurrentHealth=_inFightEnemyData.baseHp;
        enemySpriteSlot.sprite=_inFightEnemyData.enemySprite;
        StartCoroutine(fightManager.FightAnnouncer(_inFightEnemyData, _lvl));
        
        

    }

    public void QuitFight()
    {
        inFightMainMenuUi.SetActive(false);
        inGameUi.SetActive(true);
        Time.timeScale = 1;
        inFight = false;
    }

}

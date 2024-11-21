using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InFightMainMenu : MonoBehaviour
{
    public static bool inFight = false;
    public GameObject inFightMainMenuUi;
    public GameObject inGameUi;
    public Text enemyNameText;
    public Text enemyHealthText;
    public Text enemyLvlText;
    public Text playerLvlText;
    

    public FightManager fightManager;
    public InFightEnemyData[] enemyList;

    void Awake()
    {
        inFightMainMenuUi.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(inFight)
            {
                QuitFight();
            }
            else
            {
                StartFight(enemyList[0],1);
            }
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            StartFight(enemyList[0],3);
        }
    }

    public void StartFight(InFightEnemyData _inFightEnemyData, int _lvl)
    {
        inFightMainMenuUi.SetActive(true);
        inGameUi.SetActive(false);
        Time.timeScale = 0;
        inFight = true;
        enemyNameText.text=_inFightEnemyData.enemyName;
        enemyHealthText.text=_inFightEnemyData.baseHp+"/";
        playerLvlText.text="Lvl "+PlayerStats.playerLvl;
        enemyLvlText.text="Lvl "+_lvl;
        FightManager.enemyCurrentHealth=_inFightEnemyData.baseHp;
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

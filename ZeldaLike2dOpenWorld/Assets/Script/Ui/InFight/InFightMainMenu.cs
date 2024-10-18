using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InFightMainMenu : MonoBehaviour
{
    public static bool inFight = false;
    public GameObject inFightMainMenuUi;
    public Text enemyNameText;
    public Text enemyHealthText;
    public Text enemyLvlText;
    public Text playerLvlText;
    public PlayerLeveling playerLeveling;

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
                StartFight(enemyList[2],32);
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
        Time.timeScale = 0;
        inFight = true;
        enemyNameText.text=_inFightEnemyData.enemyName;
        enemyHealthText.text=_inFightEnemyData.baseHp+"/"+_inFightEnemyData.baseHp;
        playerLvlText.text="Lvl "+playerLeveling.playerLvl;
        enemyLvlText.text="Lvl "+_lvl;
        fightManager.FightAnnouncer(_inFightEnemyData);

    }

     public void QuitFight()
    {
        inFightMainMenuUi.SetActive(false);
        Time.timeScale = 1;
        inFight = false;
    }

}

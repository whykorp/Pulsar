using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLeveling : MonoBehaviour
{

    public Text lvlText;
    public Text lvlUpDescriptionText;
    public GameObject lvlUpScreen;
    public Dictionary<int, int> xpPerLvl = new Dictionary<int, int>
    {
        {1,110},
        {2,120},
        {3,140},
        {4,160},
        {5,180},
        {6,200},
        {7,220},
        {8,240},
        {9,260},
        {10,280},
        {11,300},
        {12,320},
        {13,340},
        {14,360},
        {15,380}
    };

    public void GiveXp(float _xpGived)
    {
        PlayerStats.playerXp+=_xpGived;
        if(PlayerStats.playerXp>=xpPerLvl[PlayerStats.playerLvl])
        {
            Debug.Log("Lvl Up");
            LvlUp(PlayerStats.playerLvl+1);
            PlayerStats.playerXp-=xpPerLvl[PlayerStats.playerLvl];
            PlayerStats.playerLvl+=1;
            GiveXp(0);
        }
    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(PlayerStats.playerXp);
            Debug.Log("/");
            Debug.Log(xpPerLvl[PlayerStats.playerLvl]);
        }
    }

    public IEnumerator LvlUpScreen(int lvl, string description)
    {
        yield return new WaitForSeconds(0.6f);
        lvlUpScreen.SetActive(true);
        lvlText.text = "Level " + lvl + " :";
        lvlUpDescriptionText.text = description;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.anyKeyDown);
        lvlUpScreen.SetActive(false);
    }

    void LvlUp(int _actualLvl)
    {
        switch(_actualLvl)
        {
            case 2:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(2, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 3:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(3, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 4:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(4, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 5:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(5, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 6:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(6, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 7:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(7, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 8:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(8, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 9:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(9, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 10:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(10, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 11:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(11, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 12:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(12, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 13:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(13, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 14:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(14, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;

            case 15:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                StartCoroutine(LvlUpScreen(15, "+10 Pv\n+0.1 Atk\n+0.1 Def\n+0.1 Acc"));
                break;
        }
    }
}

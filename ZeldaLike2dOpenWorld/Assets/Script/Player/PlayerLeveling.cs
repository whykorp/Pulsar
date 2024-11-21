using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLeveling : MonoBehaviour
{
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

    void LvlUp(int _actualLvl)
    {
        switch(_actualLvl)
        {
            case 2:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 3:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 4:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 5:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 6:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 7:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 8:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 9:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 10:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 11:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 12:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 13:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 14:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;

            case 15:
                PlayerStats.playerBaseAccuracy+= 0.1f;
                PlayerStats.playerBaseAttack+= 0.1f;
                PlayerStats.playerBaseDefense+= 0.1f;
                PlayerStats.playerMaxHealth+= 10;
                break;
        }
    }
}

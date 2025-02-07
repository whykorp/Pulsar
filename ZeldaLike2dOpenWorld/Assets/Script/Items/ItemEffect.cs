using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    static public void useItem(int itemID)
    {
        switch(itemID)
        {
            case 0:
                Debug.Log("You used a Health Potion");
                PlayerStats.playerCurrentHealth += 50;
                break;
            case 1:
                Debug.Log("You used a Speed Potion");
                PlayerEffect.AffectMoveSpeed(500, 50);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            useItem(0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            useItem(1);
        }
    }
}

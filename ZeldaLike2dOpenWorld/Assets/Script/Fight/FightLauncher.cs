using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLauncher : MonoBehaviour
{
    public InFightMainMenu inFightMainMenu;
    public InteractUI interactUI;
    private bool isInRange;

    public void LaunchFight(int _MobID)
    {
        inFightMainMenu.StartFight(inFightMainMenu.enemyList[_MobID], PlayerStats.playerLvl);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //interactUI.ShowUiInteract(false, Resources.Load<Sprite>("keys_59"), "Train", 0, -300);
            isInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //interactUI.HideUiInteract();
            isInRange = false;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isInRange && !InFightMainMenu.inFight)
        {
            LaunchFight(0);
        }
    }
}

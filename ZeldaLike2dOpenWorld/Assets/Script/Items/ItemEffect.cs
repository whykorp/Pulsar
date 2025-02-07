using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public Inventory inventory;
    public void UseItem(int itemID)
    {
        switch(itemID)
        {
            case 0:
                Debug.Log("You used a Health Potion");
                PlayerStats.playerCurrentHealth += 50;
                break;
            case 1:
                Debug.Log("You used a Speed Potion");
                StartCoroutine(PlayerEffect.AffectMoveSpeed(500, 10));
                break;
        }
        inventory.content[inventory.listOfItem[itemID]]--;
        inventoryUI.LoadInventoryUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseItem(0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseItem(1);
        }
    }
}

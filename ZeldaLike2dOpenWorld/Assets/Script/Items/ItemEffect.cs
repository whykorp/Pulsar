using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public Inventory inventory;
    public void UseItem(int itemID)
    {
        if(inventory.content[inventory.listOfItem[itemID]]==0)
        {
            Debug.Log("Vous n'avez pas cet item");
            return;
        }
        switch(itemID)
        {
            case 0:
                Debug.Log("You used a Health Potion");
                PlayerStats.playerCurrentHealth = math.min(PlayerStats.playerMaxHealth, PlayerStats.playerCurrentHealth + 50);
                break;
            case 1:
                Debug.Log("You used a Speed Potion");
                StartCoroutine(PlayerEffect.AffectMoveSpeed(500, 10));
                break;
            case 2:
                Debug.Log("Cet Item n'est pas utilisable");
                return;
                
        }
        inventory.content[inventory.listOfItem[itemID]]--;
        inventoryUI.LoadInventoryUI();
    }
}

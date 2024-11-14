using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();

    public PlayerMovement playerMovement;
    public int contentCurrentIndex = 0;
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance;

    private void Awake(){
        if(instance !=null){
            Debug.LogWarning("Il y plus d'une instance d'inventory dans la scène");
            return;
        }

        instance = this;
    }

    public void ConsumeItem(){
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.currentHealth += currentItem.hpGiven;
        playerMovement.moveSpeed += currentItem.speedGiven;
        content.Remove(currentItem);
        GetNextItem();
    }

    public void GetNextItem(){
        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count -1){
            contentCurrentIndex =0;
        }
    }

    public void GetPreviousItem(){
        contentCurrentIndex--;
        if(contentCurrentIndex < 0){
            contentCurrentIndex = content.Count -1;
        }
    }

    public void AddCoins(int count){
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

}

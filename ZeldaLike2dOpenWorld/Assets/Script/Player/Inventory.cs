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
    public Image itemUiImage;
    public Text itemUiName;
    public Sprite emptyItemImage;

    private void Awake(){
        if(instance !=null){
            Debug.LogWarning("Il y plus d'une instance d'inventory dans la scène");
            return;
        }

        instance = this;
    }

    void Start(){
        UpdateInventoryUI();
    }

    public void ConsumeItem(){

        if(content.Count == 0){
            return;
        }

        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.currentHealth += currentItem.hpGiven;
        playerMovement.moveSpeed += currentItem.speedGiven;
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem(){
        if(content.Count == 0){
            return;
        }
        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count -1){
            contentCurrentIndex =0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem(){
        if(content.Count == 0){
            return;
        }
        contentCurrentIndex--;
        if(contentCurrentIndex < 0){
            contentCurrentIndex = content.Count -1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI(){
        if(content.Count > 0){
            itemUiImage.sprite = content[contentCurrentIndex].image;
            itemUiName.text = content[contentCurrentIndex].name;
        } else {
            itemUiImage.sprite = emptyItemImage;
            itemUiName.text = "";
        }
        Debug.Log("Bonjour je change d'image voilà");
    }

    public void AddCoins(int count){
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

}

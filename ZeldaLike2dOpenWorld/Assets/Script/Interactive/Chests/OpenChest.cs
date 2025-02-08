using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool isInRange;
    private bool isOpen=false;
    public SpriteRenderer spriteRenderer;
    public Sprite BlueOpenedChest;
    public InteractUI interactUI;
    public int itemGivenID;
    public NewItemUI newItemUI;
    Inventory inventory;

    void Update()
    {
        if(isInRange==true)
        {
            if(isOpen==false)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    isOpen = true;
                    OnChestOpened();
                    interactUI.HideUiInteract();
                }
            }
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN RANGE");
        if (collision.CompareTag("Player"))
        {   
            if(isOpen==false){
                interactUI.ShowUiInteract(true);
            } 
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.HideUiInteract();
            isInRange = false;
        }
    }

    public void OnChestOpened(){
        Debug.Log("chest openede");
        spriteRenderer.sprite=BlueOpenedChest;
        StartCoroutine(newItemUI.ShowNewItemUI(itemGivenID));
        Inventory.instance.AddItem(itemGivenID);
    }
}

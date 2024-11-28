using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool isInRange;
    private bool isOpen;
    public SpriteRenderer spriteRenderer;
    public Sprite BlueOpenedChest;
    public InteractUI interactUI;
    public Item item;

    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isOpen = true;
                OnChestOpened();
                interactUI.HideUiInteract();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN RANGE");
        if (collision.CompareTag("Player"))
        {   
            if(isOpen==false){
                interactUI.ShowUiInteract();
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
        Inventory.instance.content.Add(item);
    }
}

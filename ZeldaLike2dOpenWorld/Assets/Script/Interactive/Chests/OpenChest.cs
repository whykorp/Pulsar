using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool isInRange;
    public bool isOpen;
    public SpriteRenderer spriteRenderer;
    public Sprite BlueOpenedChest;
    public InteractUI InteractUI;

    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isOpen = true;
            }
        }
        if(isOpen==true)
        {
            OnChestOpened();
            InteractUI.HideUiInteract();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN RANGE");
        if (collision.CompareTag("Player"))
        {   
            if(isOpen==false){
                InteractUI.ShowUiInteract();
            } 
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractUI.HideUiInteract();
            isInRange = false;
        }
    }

    public void OnChestOpened(){
        Debug.Log("chest openede");
        spriteRenderer.sprite=BlueOpenedChest;
    }
}

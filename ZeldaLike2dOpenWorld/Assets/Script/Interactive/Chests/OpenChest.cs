using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool isInRange;
    public SpriteRenderer spriteRenderer;
    public Sprite BlueOpenedChest;
    public ShowInteractUI showInteractUI;

    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                OnChestOpened();
                spriteRenderer.sprite=BlueOpenedChest;
            }
        }
        showInteractUI.ShowUiInteract(isInRange);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN RANGE");
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    public void OnChestOpened(){
        Debug.Log("chest opened");
    }
}

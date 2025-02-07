using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoins : MonoBehaviour
{
    public Inventory inventory;
    private void  OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            PlayerStats.playerCoins += 1;
            Destroy(gameObject);
        }
    }
}

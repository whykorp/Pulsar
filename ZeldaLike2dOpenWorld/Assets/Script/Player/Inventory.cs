using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();

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

    public void AddCoins(int count){
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

}

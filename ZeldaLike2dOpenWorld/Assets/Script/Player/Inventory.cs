using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> listOfItem = new List<Item>();
    public Dictionary<Item, int> content = new Dictionary<Item, int>();
    public PlayerEffect playerEffect;
    public int contentCurrentIndex = 0;
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance;
    public Image itemUiImage;
    public Text itemUiName;
    public Sprite emptyItemImage;
    public Sprite adviceUseItemImage;
    public Image adviceUseItem;

    [SerializeField] private CanvasGroup canvasgroup;
    private bool _fadeout = false;
    public float timeToFade;

    private void Awake(){
        if(instance !=null){
            Debug.LogWarning("Il y plus d'une instance d'inventory dans la scène");
            return;
        }

        instance = this;
        
        foreach (var item in listOfItem)
        {
            content.Add(item, 0);
        }

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.O)){
            Debug.Log("Inventory content:");
            foreach (var kvp in content)
            {
                Debug.Log($"{kvp.Key.name}: {kvp.Value}");
            }
        }
        if(_fadeout){
            if(canvasgroup.alpha >= 0){
                canvasgroup.alpha -= timeToFade * Time.deltaTime;
                if(canvasgroup.alpha == 0){
                    _fadeout = false;
                }
            }
        }
        //if(Input.GetKeyDown(KeyCode.Q)){
            //ConsumeItem();
        //}
    }

    public void AddItem(int itemID)
    {
        if (itemID < 0 || itemID >= listOfItem.Count)
        {
            Debug.LogWarning("Index out of range");
            return;
        }

        Item itemToAdd = listOfItem[itemID];
        if (content.ContainsKey(itemToAdd))
        {
            content[itemToAdd]++;
        }
        else
        {
            Debug.LogWarning("Item not found in inventory");
        }
    }

    public Item GetItemFromID(int itemID)
    {
        return listOfItem[itemID];
    }

    

}

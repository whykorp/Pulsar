using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();
    public PlayerEffect playerEffect;
    public int contentCurrentIndex = 0;
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance;
    public Image itemUiImage;
    public Text itemUiName;
    public Sprite emptyItemImage;

    [SerializeField] private CanvasGroup canvasgroup;
    private bool _fadeout = false;
    public float timeToFade;

    private void Awake(){
        if(instance !=null){
            Debug.LogWarning("Il y plus d'une instance d'inventory dans la scène");
            return;
        }

        instance = this;
    }

    void Update(){
        if(_fadeout){
            if(canvasgroup.alpha >= 0){
                canvasgroup.alpha -= timeToFade * Time.deltaTime;
                if(canvasgroup.alpha == 0){
                    _fadeout = false;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            ConsumeItem();
        }
    }

    void FixedUpdate(){

    }

    void Start(){
        StartCoroutine(UpdateInventoryUI());
    }

    public void ConsumeItem(){

        if(content.Count == 0){
            return;
        }

        Item currentItem = content[contentCurrentIndex];
        PlayerStats.playerCurrentHealth += currentItem.hpGiven;
        playerEffect.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        StartCoroutine(UpdateInventoryUI());
    }

    public void GetNextItem(){
        if(content.Count == 0){
            return;
        }
        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count -1){
            contentCurrentIndex =0;
        }
        StartCoroutine(UpdateInventoryUI());
    }

    public void GetPreviousItem(){
        if(content.Count == 0){
            return;
        }
        contentCurrentIndex--;
        if(contentCurrentIndex < 0){
            contentCurrentIndex = content.Count -1;
        }
        StartCoroutine(UpdateInventoryUI());
    }

    public IEnumerator UpdateInventoryUI(){
        if(content.Count > 0){
            itemUiImage.sprite = content[contentCurrentIndex].image;
            itemUiName.text = content[contentCurrentIndex].name;
            canvasgroup.alpha = 1;
            yield return new WaitForSecondsRealtime(3);
            FadeOut();
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

    public void FadeOut(){
        _fadeout = true;
    }

}

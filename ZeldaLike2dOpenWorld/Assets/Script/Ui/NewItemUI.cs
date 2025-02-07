using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewItemUI : MonoBehaviour
{
    public Image newItemSprite;
    public Text newItemText;

    [SerializeField] private CanvasGroup canvasgroup;
    private bool _fadeout = false;
    public float timeToFade;


    void Awake(){
        canvasgroup.alpha = 0;
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
    }

    public void FadeOut(){
        _fadeout = true;
    }

    public IEnumerator ShowNewItemUI(int itemID){
        Item currentItem = Inventory.instance.listOfItem[itemID];
        newItemSprite.sprite = currentItem.image;
        newItemText.text = "+ " + currentItem.name;
        canvasgroup.alpha = 1;
        yield return new WaitForSecondsRealtime(1);
        FadeOut();
    }

}

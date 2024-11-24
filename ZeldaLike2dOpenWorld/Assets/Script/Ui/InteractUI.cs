using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    public Text adviceUiText;
    public Image adviceUiImage;

    [SerializeField] private CanvasGroup canvasgroup;
    private bool _fadeout = false;
    public float timeToFade;

    void Awake()
    {
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

    public void ShowUiInteract(){
        canvasgroup.alpha = 1;
    }

    public void HideUiInteract()
    {
        FadeOut();
    }

    public void ChangeImageInteractUi(Sprite _sprite)
    {
        adviceUiImage.sprite=_sprite;
    }

    public void ChangeTextInteractUi(string _text)
    {
        adviceUiText.text=_text;
    }

    public void FadeOut(){
        _fadeout = true;
    }
}

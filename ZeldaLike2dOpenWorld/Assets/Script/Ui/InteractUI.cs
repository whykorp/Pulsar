using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    public Text adviceUiText;
    public Image adviceUiImage;
    public Sprite defaultSprite;
    public int defaultlocationX;
    public int defaultlocationY;

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

    public void ShowUiInteract(bool isDefault, Sprite _sprite = null, string _text = "Interact", int locationX = 1, int locationY = 1){
        if(isDefault){
            adviceUiImage.sprite=defaultSprite;
            adviceUiText.text="Interact";
            adviceUiImage.rectTransform.localPosition = new Vector3(defaultlocationX-250, defaultlocationY, 0);
            adviceUiText.rectTransform.localPosition = new Vector3(defaultlocationX, defaultlocationY, 0);
        }
        else{
            adviceUiImage.sprite=_sprite;
            adviceUiText.text=_text;
            adviceUiImage.rectTransform.localPosition = new Vector3(locationX-250, locationY, 0);
            adviceUiText.rectTransform.localPosition = new Vector3(defaultlocationX, defaultlocationY, 0);
        }
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

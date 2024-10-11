using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    public Text adviceUiText;
    public Image adviceUiImage;

    void Awake()
    {
        HideUiInteract();
    }   

    public void ShowUiInteract(){
        adviceUiText.enabled = true;
        adviceUiImage.enabled = true;
    }

    public void HideUiInteract()
    {
        adviceUiText.enabled = false;
        adviceUiImage.enabled = false;
    }

    public void ChangeImageInteractUi(Sprite _sprite)
    {
        adviceUiImage.sprite=_sprite;
    }

    public void ChangeTextInteractUi(string _text)
    {
        adviceUiText.text=_text;
    }
}

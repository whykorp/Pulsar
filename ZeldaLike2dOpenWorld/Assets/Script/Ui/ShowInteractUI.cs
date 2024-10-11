using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractUI : MonoBehaviour
{
    public Text adviceUiText;
    public Image adviceUiImage;

    public void ShowUiInteract(bool _isShowed){
        adviceUiText.enabled = _isShowed;
        adviceUiImage.enabled = _isShowed;
    }
}

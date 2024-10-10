using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageUi : MonoBehaviour
{
    public Image image;
    public TerminalsActivation terminalsActivation;
    void Update(){
            image.enabled=terminalsActivation.isInRange;
    }
    
    
    
}

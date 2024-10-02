using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageUi : MonoBehaviour
{
    public Image image;
    public SavePoint savePoint;
    void Update(){
            image.enabled=savePoint.isInRange;
    }
    
    
    
}

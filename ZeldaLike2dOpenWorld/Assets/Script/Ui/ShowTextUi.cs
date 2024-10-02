using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextUi : MonoBehaviour
{
    public Text text;
    public SavePoint savePoint;
    void Update(){
            text.enabled=savePoint.isInRange;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextUi : MonoBehaviour
{
    private Text text;
    public SavePoint savePoint;
    void Awake(){
        text = GetComponent<Text>();
    }
    void Update(){
        text.enabled=savePoint.isInRange;
    }
}

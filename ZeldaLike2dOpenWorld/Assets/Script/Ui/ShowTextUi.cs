using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextUi : MonoBehaviour
{
<<<<<<< Updated upstream
    private Text text;
    public SavePoint savePoint;
    void Awake(){
        text = GetComponent<Text>();
    }
    void Update(){
        text.enabled=savePoint.isInRange;
=======
    public Text text;
    public TerminalsActivation terminalsActivation;
    void Update(){
            text.enabled=terminalsActivation.isInRange;
>>>>>>> Stashed changes
    }
}

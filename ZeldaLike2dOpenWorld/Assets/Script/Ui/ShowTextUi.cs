using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowTextUi : MonoBehaviour
{
    public Text text;
    public TerminalsActivation terminalsActivation;
    void Update()
    {
    text.enabled=terminalsActivation.isInRange;
    }
}
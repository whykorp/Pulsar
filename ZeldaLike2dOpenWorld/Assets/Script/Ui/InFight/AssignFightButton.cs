using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignFightButton : MonoBehaviour
{
    public ModulePanelData modulePanel;
    public Text textModuleButton1;
    public Text textModuleButton2;
    public Text textModuleButton3;
    public Text textModuleButton4;
    
    public void UpdateModuleButton()
    {
        textModuleButton1.text=modulePanel.textSlot1;
        textModuleButton2.text=modulePanel.textSlot2;
        textModuleButton3.text=modulePanel.textSlot3;
        textModuleButton4.text=modulePanel.textSlot4;
    }

    
}

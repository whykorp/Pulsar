using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModulePanelData", menuName = "My Game/ModulePanelData")]
public class ModulePanelData : ScriptableObject
{
    public string textSlot1;
    public string textSlot2;
    public string textSlot3;
    public string textSlot4;

    public AttackPanelData fonctionSlot1;
    public AttackPanelData fonctionSlot2;
    public AttackPanelData fonctionSlot3;
    public AttackPanelData fonctionSlot4;
}

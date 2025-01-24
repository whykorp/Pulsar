using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TerminalGui : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject terminalUI;
    public GameObject accesMenu;
    public GameObject chooseModuleMenu;

    public GameObject choosedModuleIndicator1;
    public GameObject choosedModuleIndicator2;
    public GameObject choosedModuleIndicator3;
    public GameObject choosedModuleIndicator4;
    public ModulePanelData modulePanelData;
    public int choosedModuleSlot;
    public AttackPanelData[] attackPanelDatas;
    public Text textModuleSlot1;
    public Text textModuleSlot2;
    public Text textModuleSlot3;
    public Text textModuleSlot4;

    void Awake()
    {
        choosedModuleIndicator1.SetActive(false);
        choosedModuleIndicator2.SetActive(false);
        choosedModuleIndicator3.SetActive(false);
        choosedModuleIndicator4.SetActive(false);
        terminalUI.SetActive(false);
    }
    public void OpenTerminalUi()
    {
        inGameUI.SetActive(false);
        terminalUI.SetActive(true);
        chooseModuleMenu.SetActive(false);
        Time.timeScale=0;
    }   

    public void OnAccesChooseModuleMenuButtonClicked()
    {
        chooseModuleMenu.SetActive(true);
        accesMenu.SetActive(false);
    }

    public void AssignModuleToSlot(int _moduleNumber)
    {
        switch(choosedModuleSlot){
            case 1:
                Debug.Log("Module "+_moduleNumber+" assigned to slot 1");
                textModuleSlot1.text = attackPanelDatas[_moduleNumber].name;
                modulePanelData.textSlot1=attackPanelDatas[_moduleNumber].name;
                modulePanelData.fonctionSlot1=attackPanelDatas[_moduleNumber];
                break;
            
            case 2:
                Debug.Log("Module "+_moduleNumber+" assigned to slot 2");
                textModuleSlot2.text = attackPanelDatas[_moduleNumber].name;
                modulePanelData.textSlot2=attackPanelDatas[_moduleNumber].name;
                modulePanelData.fonctionSlot2=attackPanelDatas[_moduleNumber];
                break;

            case 3:
                Debug.Log("Module "+_moduleNumber+" assigned to slot 3");
                textModuleSlot3.text = attackPanelDatas[_moduleNumber].name;
                modulePanelData.textSlot3=attackPanelDatas[_moduleNumber].name;
                modulePanelData.fonctionSlot3=attackPanelDatas[_moduleNumber];
                break;

            case 4:
                Debug.Log("Module "+_moduleNumber+" assigned to slot 4");
                textModuleSlot4.text = attackPanelDatas[_moduleNumber].name;
                modulePanelData.textSlot4=attackPanelDatas[_moduleNumber].name;
                modulePanelData.fonctionSlot4=attackPanelDatas[_moduleNumber];
                break;
        }
    }

    public void OnChoosingModuleSlot(int _slotNumber)
    {
        switch(_slotNumber){
            case 1:
                choosedModuleIndicator1.SetActive(true);
                choosedModuleIndicator2.SetActive(false);
                choosedModuleIndicator3.SetActive(false);
                choosedModuleIndicator4.SetActive(false);
                choosedModuleSlot=1;
                break;
            
            case 2:
                choosedModuleIndicator1.SetActive(false);
                choosedModuleIndicator2.SetActive(true);
                choosedModuleIndicator3.SetActive(false);
                choosedModuleIndicator4.SetActive(false);
                choosedModuleSlot=2;
                break;

            case 3:
                choosedModuleIndicator1.SetActive(false);
                choosedModuleIndicator2.SetActive(false);
                choosedModuleIndicator3.SetActive(true);
                choosedModuleIndicator4.SetActive(false);
                choosedModuleSlot=3;
                break;

            case 4:
                choosedModuleIndicator1.SetActive(false);
                choosedModuleIndicator2.SetActive(false);
                choosedModuleIndicator3.SetActive(false);
                choosedModuleIndicator4.SetActive(true);
                choosedModuleSlot=4;
                break;
        }
    }
}

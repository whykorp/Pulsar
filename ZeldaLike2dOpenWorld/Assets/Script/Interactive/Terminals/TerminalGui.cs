using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public int choosedModuleSlot;

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

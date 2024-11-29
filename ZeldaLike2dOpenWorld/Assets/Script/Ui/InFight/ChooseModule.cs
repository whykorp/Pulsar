using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseModule : MonoBehaviour
{
    public ModulePanelData modulePanel;
    public InFightPlayerAction inFightPlayerAction;

    public Text textAttackButton1;
    public Text textAttackButton2;
    public Text textAttackButton3;
    public Text textAttackButton4;
    static int actualAttackOnButton1;
    static int actualAttackOnButton2;
    static int actualAttackOnButton3;
    static int actualAttackOnButton4;
    
    public GameObject modulePanelUi;
    public GameObject attackPanelUi;

    public void ChooseAttackModule(int _button)
    {
        switch(_button)
        {
            case 1:
                SetAttackModule(modulePanel.fonctionSlot1);
                break;

            case 2:
                SetAttackModule(modulePanel.fonctionSlot2);
                break;

            case 3:
                SetAttackModule(modulePanel.fonctionSlot3);
                break;

            case 4:
                SetAttackModule(modulePanel.fonctionSlot4);
                break;

        }
            

    }

    void SetAttackModule(AttackPanelData _attackModule)
    {
        textAttackButton1.text=_attackModule.textSlot1;
        textAttackButton2.text=_attackModule.textSlot2;
        textAttackButton3.text=_attackModule.textSlot3;
        textAttackButton4.text=_attackModule.textSlot4;

        actualAttackOnButton1=_attackModule.fonctionSlot1;
        actualAttackOnButton2=_attackModule.fonctionSlot2;
        actualAttackOnButton3=_attackModule.fonctionSlot3;
        actualAttackOnButton4=_attackModule.fonctionSlot4;

        modulePanelUi.SetActive(false);
        attackPanelUi.SetActive(true);
    }

    public void SetUsedAttack(int _button)
    {
        int attackUsed;
        
        switch(_button)
        {
            case 1:
                attackUsed=actualAttackOnButton1;
                UseAttack(attackUsed);
                break;

            case 2:
                attackUsed=actualAttackOnButton2;
                UseAttack(attackUsed);
                break;

            case 3:
                attackUsed=actualAttackOnButton3;
                UseAttack(attackUsed);
                break;
            
            case 4:
                attackUsed=actualAttackOnButton4;
                UseAttack(attackUsed);
                break;
        }

    }

    void UseAttack(int _attackId)
    {
        switch(_attackId)
        {
            case 1:
                StartCoroutine(inFightPlayerAction.SimpleAttack());
                break;
            case 2:
                StartCoroutine(inFightPlayerAction.PowerAttack());
                break;
            case 3:
                StartCoroutine(inFightPlayerAction.HealingQuery());
                break;
            case 4:
                StartCoroutine(inFightPlayerAction.SynergisticBuff());
                break;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public GameObject announcerFont;       // Le fond de texte pour les annonces de combat
    public GameObject announcerText;       // Le texte des annonces de combat
    public GameObject modulePanelUI;
    public GameObject attackPanelUI;
    public Text attackButtonText;
    public bool attackButtonTogle=false;

    void Update()
    {
    
    }
    public void OnAttackButtonPressed()
    {
        Debug.Log("CLICKED");
        Debug.Log(attackButtonTogle);

        if(attackButtonTogle==false && FightManager.isPlayerTurn==true){
            announcerFont.SetActive(false);
            announcerText.SetActive(false);
            modulePanelUI.SetActive(true);
            attackPanelUI.SetActive(false);
            attackButtonText.text= "Retour";
            attackButtonTogle=true;
        }
        else{
            announcerFont.SetActive(true);
            announcerText.SetActive(true);
            modulePanelUI.SetActive(false);
            attackPanelUI.SetActive(false);
            attackButtonText.text= "Attaque";
            attackButtonTogle=false;
        }
        
    }

    public void ResetPanel()
    {
        announcerFont.SetActive(true);
        announcerText.SetActive(true);
        modulePanelUI.SetActive(false);
        attackPanelUI.SetActive(false);
        attackButtonText.text= "Attaque";
        attackButtonTogle=false;
    }
}

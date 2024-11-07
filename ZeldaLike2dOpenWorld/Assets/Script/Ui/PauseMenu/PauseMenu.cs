using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsWindow;
    public GameObject mainWindow;
    public GameObject pauseMenu;
    public bool canSaveOnMenu;
    public string mainMenu = "MainMenu";
    public Button saveButton;        // Le bouton à survoler
    public Text saveButtonText;      // Le texte du bouton à changer

    private Color defaultColor = Color.white;
    private Color hoverColor = Color.cyan;

    void Start(){

        if (saveButtonText != null)
        {
            saveButtonText.color = defaultColor;
        }

        if(canSaveOnMenu==false){
            defaultColor = Color.gray;
        }
        if(canSaveOnMenu==true){
            defaultColor = Color.white;
        }
        pauseMenu.SetActive(false);

    }

    void Update()
    {
        // Vérifier si la souris est au-dessus du bouton
        if (IsMouseOverButton())
        {
            if(canSaveOnMenu == true){
                saveButtonText.color = hoverColor;   // Change la couleur au survol
            }
        }
        else
        {
            saveButtonText.color = defaultColor; // Restaure la couleur par défaut
        }
    }

    bool IsMouseOverButton()
    {
        // Vérifier si la souris est sur le bouton en utilisant Raycast
        RectTransform rectTransform = saveButton.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, null);
    }

    public void CloseMenu(){
        pauseMenu.SetActive(false);
        Debug.Log("OH OH POUTON PRESSE");
    }

    public void SaveMenu(){
        Debug.Log("Save button pressed");
    }

    public void LoadMenu(){
        Debug.Log("Load button pressed");
    }

    public void SettingsButton(){
        settingsWindow.SetActive(true);
        mainWindow.SetActive(false);
        Debug.Log("OH OH POUTON PRESSE");
    }

    public void BackSettingsButton(){
        settingsWindow.SetActive(false);
        mainWindow.SetActive(true);
        Debug.Log("OH OH POUTON PRESSE");
    }

    public void QuitGame(){
        SceneManager.LoadScene(mainMenu);
        Debug.Log("OH OH POUTON PRESSE");
    }
}



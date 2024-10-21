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
    public string mainMenu = "MainMenu";
    public void GameStart(){
        pauseMenu.SetActive(false);
        Debug.Log("OH OH POUTON PRESSE");
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

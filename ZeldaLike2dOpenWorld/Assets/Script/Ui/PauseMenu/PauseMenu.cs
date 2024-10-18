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
    }

    public void SettingsButton(){
        settingsWindow.SetActive(true);
        mainWindow.SetActive(false);
    }

    public void BackSettingsButton(){
        settingsWindow.SetActive(false);
        mainWindow.SetActive(true);
    }

    public void QuitGame(){
        SceneManager.LoadScene(mainMenu);
    }
}

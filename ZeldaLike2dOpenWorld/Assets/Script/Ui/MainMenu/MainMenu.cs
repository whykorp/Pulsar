using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public void GameStart(){
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton(){

    }

    public void QuitGame(){
        Application.Quit();
    }
}

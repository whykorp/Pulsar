using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isOpen = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (isOpen == false ){
                pauseMenu.SetActive(true);
                isOpen = true;
            } else {
                pauseMenu.SetActive(false);
                isOpen = false;
            }
        }
    }
}

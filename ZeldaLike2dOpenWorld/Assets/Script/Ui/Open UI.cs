using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameMenu;
    private bool isPauseMenuOpen = false;
    private bool isGameMenuOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseMenuOpen)
            {
                pauseMenu.SetActive(true);
                isPauseMenuOpen = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                isPauseMenuOpen = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isGameMenuOpen)
            {
                gameMenu.SetActive(true);
                isGameMenuOpen = true;
            }
            else
            {
                gameMenu.SetActive(false);
                isGameMenuOpen = false;
            }
        }
    }
}

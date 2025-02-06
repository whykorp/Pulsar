using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTest : MonoBehaviour
{
    public GameObject endScreen;
    public InteractUI interactUI;
    private bool isInRange;

    void Start()
    {
        endScreen.SetActive(false);
    }

    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                ActivateEndScreen();
                interactUI.HideUiInteract();
            }
        }
    }

    void ActivateEndScreen()
    {
        endScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.ShowUiInteract();
            isInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.HideUiInteract();
            isInRange = false;
        }
    }

    public void EndBetaButton(){
        SceneManager.LoadScene("mainMenu");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnjManager : MonoBehaviour
{

    public bool isInRange;
    public InteractUI interactUI;
    public Text pnjText;
    public Text pnjNameText;
    public string pnjName;
    public GameObject pnjDialogue;
    public String[] dialogue;

    void Awake()
    {
        pnjDialogue.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN RANGE");
        if (collision.CompareTag("Player"))
        {   
            interactUI.ShowUiInteract();
            isInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.HideUiInteract();
            isInRange = false;
            StopAllCoroutines(); // Stop any ongoing dialogue coroutine
            pnjDialogue.SetActive(false); // Hide the dialogue box
            Time.timeScale = 1; // Reset time scale
        }
    }

    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E) && !pnjDialogue.activeSelf)
            {
                    StartCoroutine(OnPnjTrigger());
                    //interactUI.HideUiInteract();
            }     
        }
    }


    public IEnumerator OnPnjTrigger()
    {
        interactUI.HideUiInteract();
        //Time.timeScale=0;
        pnjDialogue.SetActive(true);
        pnjNameText.text=pnjName;
        int i =0;
        while(i<dialogue.Length)
        {
            pnjText.text=dialogue[i];
            Debug.Log(i);
            Debug.Log(dialogue.Length);
            yield return new WaitForSecondsRealtime(0.1f);
            yield return new WaitUntil(()=>Input.anyKeyDown);
            i++;
            Debug.Log("Touched");
        }
        pnjDialogue.SetActive(false);
        //Time.timeScale=1;
        isInRange=true;
        interactUI.ShowUiInteract();
        yield break;
    }

}

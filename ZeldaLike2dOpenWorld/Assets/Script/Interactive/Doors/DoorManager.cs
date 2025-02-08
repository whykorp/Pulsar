using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public bool isOpen;
    private bool isInRange=false;
    public InteractUI interactUI;
    public GameObject openedDoor;
    public GameObject closedDoor;

    void Awake()
    {
        openedDoor=GameObject.Find("Closed");
        openedDoor=GameObject.Find("Opened");
        closedDoor.SetActive(true);
        openedDoor.SetActive(false);
        isOpen=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            interactUI.ShowUiInteract(true);
            isInRange=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            interactUI.HideUiInteract();
            isInRange=false;
        }
    }
    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(isOpen==false)
                {
                    OpenDoor();
                }
                else
                {
                    CloseDoor();
                }
            }
        }
    }
    public void OpenDoor()
    {
        Debug.Log("Open");
        isOpen=true;
        closedDoor.SetActive(false);
        openedDoor.SetActive(true);
        
    }
    public void CloseDoor()
    {
        Debug.Log("Close");
        isOpen=false;
        closedDoor.SetActive(true);
        openedDoor.SetActive(false);
        
    }
}

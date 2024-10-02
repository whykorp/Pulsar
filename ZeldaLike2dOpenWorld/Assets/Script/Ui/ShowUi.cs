using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ShowUi : MonoBehaviour
{
    
    public bool test=false;
    public TextMeshProUGUI texte;
    // Start is called before the first frame update
    void Start()
    {
        texte.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(test==true)
            {
                texte.enabled = true;
                test = false;
            }
            else
            {
                texte.enabled = false;
                test = true;
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    public bool isInRange;
    public SpriteRenderer RedSpriteBase;
    public SpriteRenderer RedSprite1;
    public SpriteRenderer RedSprite2;
    public Sprite BlueSpriteBase;
    public Sprite BlueSprite1;
    public Sprite BlueSprite2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("you saved your game");
                RedSpriteBase.sprite=BlueSpriteBase;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN RANGE");
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}

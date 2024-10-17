using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMap : MonoBehaviour
{
    public int mapsDiscovered = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite oneMap;
    public Sprite twoMap;
    public Sprite threeMap;
    public Sprite fourMap;

    void Start()
    {
        switch(mapsDiscovered){
            case 1:
                Debug.Log(mapsDiscovered);
                spriteRenderer.sprite=oneMap;
                break;

            case 2:
                Debug.Log(mapsDiscovered);
                spriteRenderer.sprite=twoMap;
                break;

            case 3:
                Debug.Log(mapsDiscovered);
                spriteRenderer.sprite=threeMap;
                break;

            case 4:
                Debug.Log(mapsDiscovered);
                spriteRenderer.sprite=fourMap;
                break;
            
            default:
                Debug.Log(mapsDiscovered);
                break;
        }
    }
}

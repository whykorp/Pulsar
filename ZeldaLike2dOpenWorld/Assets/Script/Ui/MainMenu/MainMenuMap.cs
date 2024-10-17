using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMap : MonoBehaviour
{
    public int mapsDiscovered = 0;
    public Image baseMap;
    public Sprite zeroMap;
    public Sprite oneMap;
    public Sprite twoMap;
    public Sprite threeMap;
    public Sprite fourMap;

    void Start()
    {
        ChargeMap(mapsDiscovered);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.KeypadPlus)){
            if (mapsDiscovered < 4 ){
                mapsDiscovered = mapsDiscovered + 1;
                ChargeMap(mapsDiscovered);
            }
        }

        if(Input.GetKeyDown(KeyCode.KeypadMinus)){
            if (mapsDiscovered > 0 ){
                mapsDiscovered = mapsDiscovered - 1;
                ChargeMap(mapsDiscovered);
            }
        }
    }

    public void ChargeMap(int _mapDiscovered){
        switch(_mapDiscovered){
            case 0:
                Debug.Log(mapsDiscovered);
                baseMap.sprite=zeroMap;
                break;
            case 1:
                Debug.Log(mapsDiscovered);
                baseMap.sprite=oneMap;
                break;

            case 2:
                Debug.Log(mapsDiscovered);
                baseMap.sprite=twoMap;
                break;

            case 3:
                Debug.Log(mapsDiscovered);
                baseMap.sprite=threeMap;
                break;

            case 4:
                Debug.Log(mapsDiscovered);
                baseMap.sprite=fourMap;
                break;
            
            default:
                Debug.Log(mapsDiscovered);
                break;
        }
    }
}

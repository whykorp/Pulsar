using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalsActivation : MonoBehaviour
{
    private bool isActivated=false;
    private bool isInRange;
    public SpriteRenderer RedSpriteBase;
    public SpriteRenderer RedSprite1;
    public SpriteRenderer RedSprite2;
    public Sprite BlueSpriteBase;
    public Sprite BlueSprite1;
    public Sprite BlueSprite2;
    public EnemyNavMeshPatrol enemyPathFinding;
    public EnemyPathFindingV2 EnemyNavMeshRoaming;
    public string zoneName;
    public bool refreshEnemyDetection=false;
    public TerminalZoneList terminalZoneList;
    public InteractUI interactUI;
    public TerminalGui terminalGui;

    void Update()
    {
        if(isInRange==true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(isActivated==false)
                {
                    Debug.Log("you saved your game");
                    RedSpriteBase.sprite=BlueSpriteBase;
                    RedSprite1.sprite=BlueSprite1;
                    RedSprite2.sprite=BlueSprite2;
                    terminalZoneList.ZoneList[zoneName]=true;
                    enemyPathFinding.SetTarget(enemyPathFinding.targetPosition[enemyPathFinding.destpoint], false);
                    EnemyNavMeshRoaming.resetEnemyDestination();
                    isActivated=true;
                }
                else
                {
                    terminalGui.OpenTerminalUi();
                }
            }
        }
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
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerDetectionNavhMesh : MonoBehaviour
{
    public EnemyPathFinding enemyPathFinding;
    public Transform playerTransform;
    public TerminalZoneList terminalZoneList;
    public float speedWhenPlayerDetected;
    public string zoneName;
    public bool isAttackingPlayer=false;
    public bool isPlayerExiting=false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("object détécté");
        if(collision.CompareTag("Player") && terminalZoneList.ZoneList[zoneName]==false)
        {
            Debug.Log("c'est le joueur");
            enemyPathFinding.target=playerTransform;
            if(isAttackingPlayer==false){
                enemyPathFinding.agent.speed*=speedWhenPlayerDetected;
                isAttackingPlayer=true;
            }   
        } 
    }

}

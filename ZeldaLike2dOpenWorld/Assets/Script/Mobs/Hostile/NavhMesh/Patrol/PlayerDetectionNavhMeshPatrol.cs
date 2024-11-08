using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerDetectionNavhMeshPatrol : MonoBehaviour
{
    public EnemyNavMeshPatrol enemyPathFinding;
    public Transform playerTransform;
    public TerminalZoneList terminalZoneList;
    public float speedWhenPlayerDetected;
    public string zoneName;
    public bool isAttackingPlayer=false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && terminalZoneList.ZoneList[zoneName] == false && !isAttackingPlayer)
        {   
            Debug.Log("PLAGTEDUFVUYZVEIDEZ");
            enemyPathFinding.SetTarget(playerTransform, true);
            isAttackingPlayer = true;
        }
    }

}

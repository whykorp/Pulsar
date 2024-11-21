using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePlayerDetectionNavMeshPatrol : MonoBehaviour
{
    public PlayerDetectionNavhMeshPatrol playerDetectionNavhMesh;
    public EnemyNavMeshPatrol enemyPathFinding;
    void OnTriggerExit2D(Collider2D collision)
    {
        if (playerDetectionNavhMesh.isAttackingPlayer)
        {
            //Debug.Log("Loosed");
            playerDetectionNavhMesh.isAttackingPlayer = false;
            enemyPathFinding.SetTarget(enemyPathFinding.targetPosition[enemyPathFinding.destpoint], false);
        }
    }

}

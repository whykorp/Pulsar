using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePlayerDetectionNavMesh : MonoBehaviour
{
    public PlayerDetectionNavhMesh playerDetectionNavhMesh;
    public EnemyPathFinding enemyPathFinding;
  void OnTriggerExit2D(Collider2D collision)
    {
        if(playerDetectionNavhMesh.isAttackingPlayer==true)
        {
            enemyPathFinding.agent.speed/=playerDetectionNavhMesh.speedWhenPlayerDetected;
            playerDetectionNavhMesh.isAttackingPlayer=false;
            playerDetectionNavhMesh.isPlayerExiting=true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;

public class PlayerDetectionNavMeshRoam : MonoBehaviour
{
    public EnemyPathFindingV2 enemyPathFinding;
    public Transform playerTransform;
    public TerminalZoneList terminalZoneList;
    public float speedWhenPlayerDetected;
    private float keepedSpeed;
    public string zoneName;
    public bool isAttackingPlayer = false;

    void Start()
    {
        keepedSpeed=enemyPathFinding.navMeshAgent.speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet détecté est le joueur, et si la zone est activée pour attaquer
        if (collision.CompareTag("Player") && terminalZoneList.ZoneList[zoneName] == false && !isAttackingPlayer)
        {   
            //Debug.Log("Player detected, setting enemy target to player");
            enemyPathFinding.navMeshAgent.speed = speedWhenPlayerDetected;  // Modifie la vitesse pour poursuite
            enemyPathFinding.waypoint=playerTransform;  // Définit la destination vers le joueur
            isAttackingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAttackingPlayer)
        {
            //Debug.Log("Player lost, resetting enemy destination");
            enemyPathFinding.navMeshAgent.speed = keepedSpeed;
            isAttackingPlayer = false;
            enemyPathFinding.resetEnemyDestination();  // Retourne à la patrouille
        }
    }
}

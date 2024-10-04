using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerDetectionNavhMesh : MonoBehaviour
{
    public EnemyPathFinding enemyPathFinding;
    public Transform playerTransform;
    public float speedWhenPlayerDetected;
    public bool isAttackingPlayer=false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("object détécté");
        if(collision.CompareTag("Player"))
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

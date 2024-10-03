using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public Transform playerTransform;
    private bool isDetected=false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(isDetected==false)
            {
                isDetected=true;
                for(int i=0;i <= enemyMovement.waypoints.Length;i++)
                {
                    enemyMovement.waypoints[i]=playerTransform;
                    Debug.Log("tour de boucle:"+i);
                }
            }
        } 
    }
}

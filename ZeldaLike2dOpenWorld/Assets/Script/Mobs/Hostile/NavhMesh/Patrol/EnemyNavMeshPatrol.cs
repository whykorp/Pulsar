using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshPatrol : MonoBehaviour
{
    public NavMeshAgent agent;
    public PlayerDetectionNavhMeshPatrol playerDetectionNavhMesh;
    public TerminalsActivation terminalsActivation;
    public Transform[] targetPosition;
    Transform target;
    public int destpoint = 0;

    private float defaultSpeed;

    void Awake()
    {
        target = targetPosition[0];
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        defaultSpeed = agent.speed;  // Sauvegarde la vitesse par défaut
        agent.SetDestination(target.position);
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        if ((Vector3.Distance(transform.position, target.position) < 1f && !playerDetectionNavhMesh.isAttackingPlayer) || terminalsActivation.refreshEnemyDetection)
        {
            destpoint = (destpoint + 1) % targetPosition.Length;
            SetTarget(targetPosition[destpoint], false);
            terminalsActivation.refreshEnemyDetection = false;
        }
    }

    public void SetTarget(Transform newTarget, bool isPlayer)
    {
        target = newTarget;
        agent.SetDestination(target.position);
        
        if (isPlayer)
        {
            agent.speed = playerDetectionNavhMesh.speedWhenPlayerDetected;
        }
        else
        {
            agent.speed = defaultSpeed;
        }
        Debug.Log("Target Set");
    }
}

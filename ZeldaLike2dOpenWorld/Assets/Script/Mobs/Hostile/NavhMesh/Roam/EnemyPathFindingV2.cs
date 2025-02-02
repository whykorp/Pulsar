using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFindingV2 : MonoBehaviour
{
    public float searchRadius = 5.0f;
    public Transform enemy;
    public NavMeshAgent navMeshAgent;
    Vector3 targetPosition;
    public PlayerDetectionNavMeshRoam playerDetectionNavhMesh;
    //public TerminalsActivation terminalsActivation;
    private Vector2 testposition;
    public Transform waypoint;
    Transform waypointTrue;

    void Awake()
    {
        enemy = GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        waypointTrue=waypoint;
    }

    void Start()
    {
        GenerateRandomTransformInSphere(enemy.position, searchRadius);
        navMeshAgent.SetDestination(waypoint.position);
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        //Debug.Log(targetPosition);
    }

    private void Update()
    {
        navMeshAgent.SetDestination(waypoint.position);
        // Vérifie si l'ennemi est proche de la cible et si l'une des conditions de changement de destination est remplie
        if (Vector3.Distance(transform.position, waypoint.position) < 1f && !playerDetectionNavhMesh.isAttackingPlayer)
        {
            // Génère une nouvelle destination
            GenerateRandomTransformInSphere(enemy.position, searchRadius);
            waypointTrue=waypoint;
            //Debug.Log(targetPosition);
        }
        
    }

    public void resetEnemyDestination()
    {
        waypoint=waypointTrue;
        navMeshAgent.SetDestination(waypoint.position);
    }

    void GenerateRandomTransformInSphere(Vector3 center, float radius)
    {
        Vector3 randomPoint;
        NavMeshHit hit;
        bool isOnNavMesh = false;

        // Continue de générer des points jusqu'à ce qu'on trouve une position valide sur la NavMesh
        do
        {
            // Génère un point aléatoire en 2D (x et y uniquement) autour du "center"
            Vector2 randomPoint2D = Random.insideUnitCircle * radius;
            randomPoint = new Vector3(randomPoint2D.x, randomPoint2D.y, 0); // y varie maintenant aussi et z est fixé à 0

            // Vérifie si le point est sur la NavMesh
            isOnNavMesh = NavMesh.SamplePosition(randomPoint, out hit, 0.1f, NavMesh.AllAreas);

        } while (!isOnNavMesh); // Répète jusqu'à ce que le point soit valide sur la NavMesh
        waypoint.position = new Vector3(hit.position.x, hit.position.y,0);
        // Retourne la position validée sur la NavMesh, avec z = 0 et y qui varie comme x
    }   

}

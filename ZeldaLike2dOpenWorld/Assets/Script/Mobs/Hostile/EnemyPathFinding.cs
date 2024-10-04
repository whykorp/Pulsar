using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFinding : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] targetPosition;
    public Transform target;

    void Awake(){
        target = targetPosition[Random.Range(0,targetPosition.Length)];
    }
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        //Debug.Log(Vector3.Distance(transform.position, target.position));
        if(Vector3.Distance(transform.position, target.position) < 1f)
        {
            //Debug.Log("WAYPOINT REACHED");
            target = targetPosition[Random.Range(0,targetPosition.Length)];
        }
       
    }
}

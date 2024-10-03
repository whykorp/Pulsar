using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            Debug.Log("WAYPOINT REACHED");
            destPoint = (destPoint + 1) % waypoints.Length;
            Debug.Log("New Waypoint:"+destPoint);
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    public void PlayerDetected()
    {
        Debug.Log("Player Detected");
        destPoint = (destPoint + 1) % waypoints.Length;
        Debug.Log("New Waypoint:"+destPoint);
        target = waypoints[destPoint];
        graphics.flipX = !graphics.flipX;
    }

}

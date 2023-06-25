using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveToNextWaypoint();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }
}



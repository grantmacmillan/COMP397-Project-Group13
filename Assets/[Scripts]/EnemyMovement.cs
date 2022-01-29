using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;

    private Quaternion lookRotation;
    private Transform target;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        target = WaypointList.waypoints[0];
        Vector3 dir = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(dir);
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < 0.05)
        {
            
            GetNextWaypointFromIndex();
        }
    }

    void GetNextWaypointFromIndex()
    {
        currentWaypointIndex++;
        target = WaypointList.waypoints[currentWaypointIndex];

        Vector3 dir = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(dir);
    }
}

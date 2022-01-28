using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Transform target;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        target = WaypointList.waypoints[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);

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
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}

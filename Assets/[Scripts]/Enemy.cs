using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum State
    {
        Idle,
        Walk,
        Run,
        Dead
    }

    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;

    private State state;
    private Animator animator;
    private Quaternion lookRotation;
    private Transform target;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        state = State.Walk;
        animator = GetComponent<Animator>();
        target = WaypointList.waypoints[0];
        Vector3 dir = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(dir);
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                animator.SetFloat("movementSpeed", 0f);
                break;
            case State.Walk:
                animator.SetFloat("movementSpeed", movementSpeed);
                break;
            case State.Run:
                animator.SetFloat("movementSpeed", movementSpeed*2);
                break;
            case State.Dead:
                animator.SetBool("isDead", true);
                break;

        } 

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
        if (currentWaypointIndex > WaypointList.waypoints.Length)
        {
            KillEnemy();
        }

            target = WaypointList.waypoints[currentWaypointIndex];

        Vector3 dir = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(dir);
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}

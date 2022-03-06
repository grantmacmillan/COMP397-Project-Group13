using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float health;
    public Image healthBar;

    private float startHealth;
    private State state;
    private Animator animator;
    private Quaternion lookRotation;
    private Transform target;
    private int currentWaypointIndex = 0;

    public int lives = 5;
    public int goldAmount;
    PlayerLives instance = new();

    private void Start()
    {
        startHealth = health;
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
                gameObject.tag = "Dead";
                break;

        }

        if (state == State.Walk)
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
    }

    void GetNextWaypointFromIndex()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex > WaypointList.waypoints.Length)
        {
            DestroyEnemy();
            //put remove life code here
            //PlayerLives.LoseLife(1);
            
            //instance.LoseLife();
            Debug.Log("this is where u lose a life");
        }

        target = WaypointList.waypoints[currentWaypointIndex];

        Vector3 dir = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(dir);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            StartCoroutine(KillEnemy());
        }
    }

    private IEnumerator KillEnemy()
    {
        ResourceManager.gold += goldAmount;
        FindObjectOfType<Sound_Manager>().Play("MonsterDeath1");
        state = State.Dead;
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(4f); 
        Destroy(gameObject);
    }

    public void DestroyEnemy()
    {
        lives--;
        FindObjectOfType<PlayerLives>().LoseLife(lives);
        FindObjectOfType<Sound_Manager>().Play("LosingLife");
        Destroy(gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IPooledObject
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

    public float startHealth;
    private State state;
    private Animator animator;
    private Quaternion lookRotation;
    private Transform target;
    private int currentWaypointIndex = 0;

    public int goldAmount;
    private int lives = 5;
    PlayerLives instance = new();

    public void OnObjectSpawn()
    {
        health = startHealth;
        state = State.Walk;
        animator = GetComponent<Animator>();
        healthBar.fillAmount = 1;
        target = WaypointList.waypoints[0];
        currentWaypointIndex = 0;
        gameObject.tag = "Enemy";
        lookRotation = Quaternion.Euler(0, 90, 0);
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
                animator.SetFloat("movementSpeed", movementSpeed * 2);
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
        if (currentWaypointIndex < WaypointList.waypoints.Length)
        {
            target = WaypointList.waypoints[currentWaypointIndex];
            Vector3 dir = target.position - transform.position;
            lookRotation = Quaternion.LookRotation(dir);
        }
        else
        {
            DestroyEnemy();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && state != State.Dead)
        {
            StartCoroutine(KillEnemy());
        }
    }

    private IEnumerator KillEnemy()
    {
        ResourceManager.gold += goldAmount;
        SaveManager.instance.activeSave.tempGold += goldAmount;
        FindObjectOfType<Sound_Manager>().Play("MonsterDeath1");
        state = State.Dead;
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(4f);
        ObjectPooler.Instance.poolDictionary[name].Release(gameObject);
    }

    public void DestroyEnemy()
    {
        lives--;
        FindObjectOfType<PlayerLives>().LoseLife(lives);
        FindObjectOfType<Sound_Manager>().Play("LosingLife");
        ObjectPooler.Instance.poolDictionary[name].Release(gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float turretRange = 2.5f;
    public float rotationSpeed = 5f;
    public float fireRate = 1f;
    private float fireCooldown = 0f;

    [Header("Unity")]
    private Transform cannonTransform;

    public string audioName;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private void Awake() {
        //Counts which tower was previously placed
        if (this.name.StartsWith("Cannon") && !SaveManager.instance.hasLoaded) {
            //Adds to save data
            SaveManager.instance.activeSave.cannonPositions.Add(this.transform.position.x);
            SaveManager.instance.activeSave.cannonPositions.Add(this.transform.position.y);
            SaveManager.instance.activeSave.cannonPositions.Add(this.transform.position.z);

            //Counts the number of cannon turrets placed
            SaveManager.instance.activeSave.cannonCount++;
        }
        if (this.name.StartsWith("Balista") && !SaveManager.instance.hasLoaded) {
            //Adds to save data
            SaveManager.instance.activeSave.balistaPositions.Add(this.transform.position.x);
            SaveManager.instance.activeSave.balistaPositions.Add(this.transform.position.y);
            SaveManager.instance.activeSave.balistaPositions.Add(this.transform.position.z);

            //Counts the number of balista turrets placed
            SaveManager.instance.activeSave.balistaCount++;
        }
        if (this.name.StartsWith("Blaster") && !SaveManager.instance.hasLoaded) {
            //Adds to save data
            SaveManager.instance.activeSave.blasterPositions.Add(this.transform.position.x);
            SaveManager.instance.activeSave.blasterPositions.Add(this.transform.position.y);
            SaveManager.instance.activeSave.blasterPositions.Add(this.transform.position.z);

            //Counts the number of blaster turrets placed
            SaveManager.instance.activeSave.blasterCount++;
        }
    }
    private void Start() {
        cannonTransform = transform.GetChild(0).transform;
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }

    private void Update() {
        CheckEnemyDistance();

        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(cannonTransform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            cannonTransform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCooldown <= 0f)
            {
                Fire();
                fireCooldown = 1f / fireRate;
            }

            fireCooldown -= Time.deltaTime;
        }
    }

    private void Fire() {
        FindObjectOfType<Sound_Manager>().Play(audioName);

        GameObject projectileObject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Projectile projectile = projectileObject.GetComponent<Projectile>();

        projectile.SetTarget(target);
    }

    private void CheckEnemyDistance() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float closestEnemy = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemyDistance < closestEnemy)
            {
                closestEnemy = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null & closestEnemy <= turretRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}

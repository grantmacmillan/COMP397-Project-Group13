using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

   public float turretRange = 2.5f, rotationSpeed = 5f;
   private Transform target, cannonTransform;

   private void Start()
   {
       cannonTransform = transform.GetChild(0).transform;
    }
   void OnDrawGizmosSelected()
   {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, turretRange);
   }

   private void Update()
   {
       CheckEnemyDistance();

       if (target != null)
       {
           Vector3 dir = target.position - transform.position;
           Quaternion lookRotation = Quaternion.LookRotation(dir);
           Vector3 rotation = Quaternion.Lerp(cannonTransform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
           cannonTransform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
       }
   }

   private void CheckEnemyDistance()
   {
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

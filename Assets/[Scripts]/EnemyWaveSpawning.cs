using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawning : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public GameObject[] enemies;
    //int randomEnemyIndex = Random.Range(0, enemies.Length);

    public float waveTimer = 5f;
    public float enemySpawnGapTime;
    private float countdown = 2f;

    private int waveNum = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = waveTimer;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNum++;
        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnGapTime);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPoint.position, spawnPoint.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawning : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float waveTimer = 5f;
    private float countdown = 2f;


    private int waveNum = 1;

    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = waveTimer;
        }

        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
        }
        waveNum++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

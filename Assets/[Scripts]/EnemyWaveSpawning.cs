using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWaveSpawning : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public GameObject[] enemiesToSpawn;
    //public GameObject[] enemiesAlive;
    public List<GameObject> enemiesAlive = new List<GameObject>();

    public List<Wave> waves = new List<Wave>();
    //int randomEnemyIndex = Random.Range(0, enemies.Length);

    public float enemySpawnGapTime;

    public int waveCompletedGold = 5;

    public int waveNum = 0;

    public bool firstRoundStarted = false;

    private void Start()
    {
        // skeletons, orcs, vampires
        waves.Add(new Wave(3, 0, 0));
        waves.Add(new Wave(5, 1, 0));
        waves.Add(new Wave(5, 2, 0));
        waves.Add(new Wave(8, 4, 0));
        waves.Add(new Wave(10, 4, 0));
        waves.Add(new Wave(10, 5, 0));
        waves.Add(new Wave(20, 0, 0));
        waves.Add(new Wave(0, 10, 0));
        waves.Add(new Wave(0, 0, 3));
        waves.Add(new Wave(0, 0, 6));
        waves.Add(new Wave(20, 5, 1));
        waves.Add(new Wave(25, 7, 2));
        waves.Add(new Wave(30, 8, 3));
        waves.Add(new Wave(30, 8, 3));
        ResourceManager.totalWaves = waves.Count;
        

    }

    void Update()
    {
        foreach (GameObject enemy in enemiesAlive)
        {
            if (enemy == null)
            {
                enemiesAlive.Remove(enemy);
            }
        }

        if (enemiesAlive.Count == 0 && firstRoundStarted == true)
        {
            ResourceManager.gold += waveCompletedGold;
            ResourceManager.waveNum++;
            waveNum++;
            
            if (waveNum < ResourceManager.totalWaves)
            {
                //else win game
                StartCoroutine(SpawnWave(waves[waveNum]));
            }else
            {
                SceneManager.LoadScene("Game Won");
            }
        }

    }

    IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.skeleton; i++)
        {
            SpawnEnemy(0);
            yield return new WaitForSeconds(enemySpawnGapTime);
        }
        for (int i = 0; i < wave.orc; i++)
        {
            SpawnEnemy(1);
            yield return new WaitForSeconds(enemySpawnGapTime);
        }
        for (int i = 0; i < wave.vampire; i++)
        {
            SpawnEnemy(2);
            yield return new WaitForSeconds(enemySpawnGapTime);
        }
    }

    void SpawnEnemy(int enemy)
    {
        enemiesAlive.Add(Instantiate(enemiesToSpawn[enemy], spawnPoint.position, spawnPoint.rotation));
    }

    public void StartFirstWave()
    {
        StartCoroutine(SpawnWave(waves[0]));
        firstRoundStarted = true;

    }
}

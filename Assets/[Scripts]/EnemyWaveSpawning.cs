using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int waveNum = 0;

    private void Start()
    {
        // skeletons, orcs, vampires
        waves.Add(new Wave(1, 0, 0));
        waves.Add(new Wave(1, 1, 0));
        waves.Add(new Wave(2, 1, 1));
        waves.Add(new Wave(2, 2, 1));
        waves.Add(new Wave(2, 2, 2));
        waves.Add(new Wave(3, 2, 2));
        waves.Add(new Wave(3, 3, 2));
        waves.Add(new Wave(3, 3, 3));
        waves.Add(new Wave(4, 4, 4));
        waves.Add(new Wave(5, 5, 5));
        waves.Add(new Wave(6, 6, 6));
        waves.Add(new Wave(7, 7, 7));
        waves.Add(new Wave(8, 8, 8));
        StartCoroutine(SpawnWave(waves[0]));
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

        if (enemiesAlive.Count == 0)
        {
            ResourceManager.gold += waveCompletedGold;
            waveNum++;
            if (waveNum < waves.Count)
            {
                //else win game
                StartCoroutine(SpawnWave(waves[waveNum]));
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
}

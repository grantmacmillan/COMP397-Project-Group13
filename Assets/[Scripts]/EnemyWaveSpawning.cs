using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class EnemyWaveSpawning : MonoBehaviour
{
    public static event Action<int> OnWaveCompleted;
    public static event Action OnStartGame;
    public static bool isFirstSave = false;
    public static bool isWaveCompleted = false;

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
        //5
        waves.Add(new Wave(8, 7, 0));
        waves.Add(new Wave(10, 5, 0));
        waves.Add(new Wave(15, 8, 1));
        waves.Add(new Wave(0, 15, 1));
        waves.Add(new Wave(0, 0, 4));
        //10
        waves.Add(new Wave(20, 5, 3));
        waves.Add(new Wave(25, 7, 3));
        waves.Add(new Wave(20, 12, 3));
        waves.Add(new Wave(15, 20, 5));
        waves.Add(new Wave(0, 0, 12));
        //15
        waves.Add(new Wave(15, 18, 13));
        waves.Add(new Wave(5, 10, 18));
        waves.Add(new Wave(0, 5, 28));
        waves.Add(new Wave(0, 0, 35));
        waves.Add(new Wave(0, 0, 45));
        //20
        waves.Add(new Wave(0, 0, 55));
        ResourceManager.totalWaves = waves.Count;
    }

    void Update()
    {
        /* for (int i = 0; i < enemiesAlive.Count; i++ )
         {
             if (enemiesAlive[i] == null)
             {
                 enemiesAlive.RemoveAt(i);
             }
         }*/

        //Beginning of a new wave
        if (AreAllEnemiesInactive() && firstRoundStarted == true)
        {

            waveCompletedGold += 1;
            ResourceManager.gold += waveCompletedGold;
            ResourceManager.waveNum++;
            waveNum++;
            if (OnWaveCompleted != null)
            {
                OnWaveCompleted(waveCompletedGold);
            }

            //Transfert temporary date to permanent data
            SaveManager.instance.activeSave.tempGold += waveCompletedGold;
            SaveManager.instance.activeSave.goldAmount += SaveManager.instance.activeSave.tempGold;
            SaveManager.instance.activeSave.tempGold = 0;
            SaveManager.instance.activeSave.gemAmount += SaveManager.instance.activeSave.tempGem;
            SaveManager.instance.activeSave.tempGem = 0;
            SaveManager.instance.activeSave.woodAmount += SaveManager.instance.activeSave.tempWood;
            SaveManager.instance.activeSave.tempWood = 0;

            for (int i = 0; i < SaveManager.instance.activeSave.tempWoodTowerCount * 3; i++)
                SaveManager.instance.activeSave.woodTowerPositions.Add(SaveManager.instance.activeSave.tempWoodTowerPositions[i]);

            for (int i = 0; i < SaveManager.instance.activeSave.tempGemTowerCount * 3; i++)
                SaveManager.instance.activeSave.gemTowerPositions.Add(SaveManager.instance.activeSave.tempGemTowerPositions[i]);

            for (int i = 0; i < SaveManager.instance.activeSave.tempCannonCount * 3; i++)
                SaveManager.instance.activeSave.cannonPositions.Add(SaveManager.instance.activeSave.tempCannonPositions[i]);

            for (int i = 0; i < SaveManager.instance.activeSave.tempBalistaCount * 3; i++)
                SaveManager.instance.activeSave.balistaPositions.Add(SaveManager.instance.activeSave.tempBalistaPositions[i]);

            for (int i = 0; i < SaveManager.instance.activeSave.tempBlasterCount * 3; i++)
                SaveManager.instance.activeSave.blasterPositions.Add(SaveManager.instance.activeSave.tempBlasterPositions[i]);

            ResetValues();

            if (waveNum < ResourceManager.totalWaves)
            {
                //else win game
                StartCoroutine(SpawnWave(waves[waveNum]));
            }
            else
            {
                SceneManager.LoadScene("Game Won");
            }
        }
    }

    bool AreAllEnemiesInactive()
    {
        foreach (GameObject enemy in enemiesAlive)
        {
            if (enemy.activeSelf)
            {
                return false;
            }
        }
        isWaveCompleted = true;
        return true;
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
        GameObject enemyObj = (ObjectPooler.Instance.SpawnFromPool(enemiesToSpawn[enemy].name, spawnPoint.position, Quaternion.Euler(0, 90, 0)));
        enemyObj.name = enemiesToSpawn[enemy].name;
        enemiesAlive.Add(enemyObj);
        //enemiesAlive.Add(Instantiate(enemiesToSpawn[enemy], spawnPoint.position, spawnPoint.rotation));
    }

    public void StartFirstWave()
    {
        if (OnStartGame != null)
        {
            OnStartGame();
        }
        if (ResourceManager.waveNum <= 1)
        {
            StartCoroutine(SpawnWave(waves[0]));
            firstRoundStarted = true;
        }
        else
        {
            StartCoroutine(SpawnWave(waves[ResourceManager.waveNum - 1]));
            firstRoundStarted = true;
        }
    }

    void ResetValues()
    {
        SaveManager.instance.activeSave.blasterCount += SaveManager.instance.activeSave.tempBlasterCount;
        SaveManager.instance.activeSave.tempBlasterCount = 0;
        SaveManager.instance.activeSave.tempBlasterPositions.Clear();

        SaveManager.instance.activeSave.balistaCount += SaveManager.instance.activeSave.tempBalistaCount;
        SaveManager.instance.activeSave.tempBalistaCount = 0;
        SaveManager.instance.activeSave.tempBalistaPositions.Clear();

        SaveManager.instance.activeSave.cannonCount += SaveManager.instance.activeSave.tempCannonCount;
        SaveManager.instance.activeSave.tempCannonCount = 0;
        SaveManager.instance.activeSave.tempCannonPositions.Clear();

        SaveManager.instance.activeSave.gemTowerCount += SaveManager.instance.activeSave.tempGemTowerCount;
        SaveManager.instance.activeSave.tempGemTowerCount = 0;
        SaveManager.instance.activeSave.tempGemTowerPositions.Clear();

        SaveManager.instance.activeSave.woodTowerCount += SaveManager.instance.activeSave.tempWoodTowerCount;
        SaveManager.instance.activeSave.tempWoodTowerCount = 0;
        SaveManager.instance.activeSave.tempWoodTowerPositions.Clear();


        isWaveCompleted = false;
    }
}
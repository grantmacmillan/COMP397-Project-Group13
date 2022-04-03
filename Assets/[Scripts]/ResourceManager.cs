using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    public TextMeshProUGUI goldText, woodText, gemsText, waveText, livesText;
    public static int gold, wood, gems, waveNum, totalWaves, currentLives;
    public int startingGold = 999, startingWood = 999, startingGems = 999;
    public GameObject pauseMenuUI;
    public static ResourceManager Instance;

    [SerializeField] private GameObject cannonPrefab, balistaPrefab, blasterPrefab, woodPrefab, gemPrefab;

    private void Awake()
    {
        Instance = this;
    }
    //Loads Or Start A New Game
    void Start()
    {
        if (SaveManager.instance.hasLoaded)
        {
            //Restart Temporary variables Count
            SaveManager.instance.activeSave.tempGold = 0;
            SaveManager.instance.activeSave.tempWood = 0;
            SaveManager.instance.activeSave.tempGem = 0;

            SaveManager.instance.activeSave.tempCannonPositions.Clear();
            SaveManager.instance.activeSave.tempBlasterPositions.Clear();
            SaveManager.instance.activeSave.tempBalistaPositions.Clear();
            SaveManager.instance.activeSave.tempWoodTowerPositions.Clear();
            SaveManager.instance.activeSave.tempGemTowerPositions.Clear();

            SaveManager.instance.activeSave.tempBlasterCount = 0;
            SaveManager.instance.activeSave.tempBalistaCount = 0;
            SaveManager.instance.activeSave.tempCannonCount = 0;
            SaveManager.instance.activeSave.tempWoodTowerCount = 0;
            SaveManager.instance.activeSave.tempGemTowerCount = 0;

            //Loading gold
            int loadedGold = SaveManager.instance.activeSave.goldAmount;
            goldText.text = loadedGold.ToString();
            gold = loadedGold;

            //Loading wood
            int loadedWood = SaveManager.instance.activeSave.woodAmount;
            woodText.text = loadedWood.ToString();
            wood = loadedWood;

            //Loading gems
            int loadedGems = SaveManager.instance.activeSave.gemAmount;
            gemsText.text = loadedGems.ToString();
            gems = loadedGems;

            //Loading Wave Number
            int loadedWaveNumber = SaveManager.instance.activeSave.waveNumber;
            waveText.text = loadedWaveNumber.ToString();
            waveNum = loadedWaveNumber;
            Debug.Log("Resource Manager wave number: " + waveNum);

            //Loading Lives
            int loadedLives = SaveManager.instance.activeSave.livesAmount;
            livesText.text = loadedLives.ToString();
            currentLives = loadedLives;


            Debug.Log("Cannon count: " + SaveManager.instance.activeSave.cannonCount);
            //Instantiating turrets
            //CANNON
            InstantiateTowers(SaveManager.instance.activeSave.cannonCount, SaveManager.instance.activeSave.cannonPositions, cannonPrefab);

            //BALISTA
            InstantiateTowers(SaveManager.instance.activeSave.balistaCount, SaveManager.instance.activeSave.balistaPositions, balistaPrefab);

            //BLASTER
            InstantiateTowers(SaveManager.instance.activeSave.blasterCount, SaveManager.instance.activeSave.blasterPositions, blasterPrefab);

            //WOOD TOWER
            InstantiateTowers(SaveManager.instance.activeSave.woodTowerCount, SaveManager.instance.activeSave.woodTowerPositions, woodPrefab);

            //GEM TOWER
            InstantiateTowers(SaveManager.instance.activeSave.gemTowerCount, SaveManager.instance.activeSave.gemTowerPositions, gemPrefab);

            //Resetting loading state
            SaveManager.instance.hasLoaded = false;
        }
        else
        {
            EnemyWaveSpawning.isFirstSave = true;

            //If there is nothing to load
            SaveManager.instance.activeSave.tempGold = 0;
            SaveManager.instance.activeSave.tempWood = 0;
            SaveManager.instance.activeSave.tempGem = 0;

            SaveManager.instance.activeSave.tempCannonPositions.Clear();
            SaveManager.instance.activeSave.tempBlasterPositions.Clear();
            SaveManager.instance.activeSave.tempBalistaPositions.Clear();
            SaveManager.instance.activeSave.tempWoodTowerPositions.Clear();
            SaveManager.instance.activeSave.tempGemTowerPositions.Clear();

            SaveManager.instance.activeSave.tempBlasterCount = 0;
            SaveManager.instance.activeSave.tempBalistaCount = 0;
            SaveManager.instance.activeSave.tempCannonCount = 0;
            SaveManager.instance.activeSave.tempWoodTowerCount = 0;
            SaveManager.instance.activeSave.tempGemTowerCount = 0;

            gold = startingGold;
            SaveManager.instance.activeSave.goldAmount = gold;

            wood = startingWood;
            SaveManager.instance.activeSave.woodAmount = wood;

            gems = startingGems;
            SaveManager.instance.activeSave.gemAmount = gems;

            waveNum = 1;
            SaveManager.instance.activeSave.waveNumber = waveNum;
        }
    }

    public static bool Purchase(int g, int w, int gem)
    {
        if (EnemyWaveSpawning.isFirstSave && g <= gold && w <= wood && gem <= gems)
        {
            gold -= g;
            wood -= w;
            gems -= gem;
            SaveManager.instance.activeSave.goldAmount = gold;
            SaveManager.instance.activeSave.woodAmount = wood;
            SaveManager.instance.activeSave.gemAmount = gems;
            return true;
        }

        if (!EnemyWaveSpawning.isFirstSave && g <= gold && w <= wood && gem <= gems)
        {
            gold -= g;
            wood -= w;
            gems -= gem;
            SaveManager.instance.activeSave.tempGold -= g;
            SaveManager.instance.activeSave.tempWood -= w;
            SaveManager.instance.activeSave.tempGem -= gem;
            return true;
        }
        return false;
    }

    void Update()
    {
        goldText.text = gold.ToString();
        woodText.text = wood.ToString();
        gemsText.text = gems.ToString();

        //Updating the SaveManager's numbers:
        SaveManager.instance.activeSave.livesAmount = PlayerLives.currentLives;
        SaveManager.instance.activeSave.waveNumber = waveNum;

        //waveNum++;
        waveText.text = "Wave: " + waveNum.ToString() + "/" + totalWaves.ToString();
    }

    //Instantiates Towers
    void InstantiateTowers(float count, List<float> positions, GameObject obj)
    {
        for (int i = 0; i < count; i++)
            if (i == 0)
                Instantiate(obj, new Vector3(positions[0], positions[1], positions[2]), Quaternion.identity);
            else
                Instantiate(obj, new Vector3(positions[3 * i], positions[1 + (3 * i)], positions[2 + (3 * i)]), Quaternion.identity);
    }

    public int GetGold()
    {
        return gold;
    }
    public int GetWood()
    {
        return wood;
    }
    public int GetGems()
    {
        return gems;
    }

}

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

    [SerializeField] private GameObject cannonPrefab, balistaPrefab, blasterPrefab, woodPrefab, gemPrefab;

    //Loads Or Start A New Game
    void Start() {
        if (SaveManager.instance.hasLoaded)
        {
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
        else {
            //If there is nothing to load
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

    public static bool Purchase(int g, int w, int gem) {
        if (g <= gold && w <= wood && gem <= gems) {
            gold -= g;
            wood -= w;
            gems -= gem;
            return true;
        }
        return false;
    }

    void Update() {
        goldText.text = gold.ToString();
        woodText.text = wood.ToString();
        gemsText.text = gems.ToString();

        //Updating the SaveManager's numbers:
        SaveManager.instance.activeSave.goldAmount = gold;
        SaveManager.instance.activeSave.woodAmount = wood;
        SaveManager.instance.activeSave.gemAmount = gems;
        SaveManager.instance.activeSave.livesAmount = PlayerLives.currentLives;
        SaveManager.instance.activeSave.waveNumber = waveNum;
        
        //waveNum++;
        waveText.text = "Wave: " + waveNum.ToString() + "/" + totalWaves.ToString();
    }

    //Instantiates Towers
    void InstantiateTowers(float count, List<float> positions, GameObject obj) {
        for (int i = 0; i < count; i++)
            if (i == 0)
                Instantiate(obj, new Vector3(positions[0], positions[1], positions[2]), Quaternion.identity);
            else
                Instantiate(obj, new Vector3(positions[3 * i], positions[1 + (3 * i)], positions[2 + (3 * i)]), Quaternion.identity);
    }

  /*public void LoadData()
    {
        SceneManager.LoadScene("Main Scene");
        SaveData data = SaveSystem.LoadData();
        currentLives = data.lives;
        wood = data.woods;
        gold = data.gold;
        gems = data.gems;
        waveNum = data.waveNum;
        lives.GetComponent<PlayerLives>().loadCurrentLives(currentLives);
       
        pauseMenuUI.SetActive(false);
    }*/
}

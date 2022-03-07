using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    public TextMeshProUGUI goldText, woodText, gemsText, waveText;
    public static int gold, wood, gems, waveNum, totalWaves, currentLives;
    public int startingGold = 999, startingWood = 999, startingGems = 999;
    public GameObject lives;
   

    void Start()
    {
        gold = startingGold;
        wood = startingWood;
        gems = startingGems;
        waveNum = 1;
        
    }

    public static bool Purchase(int g, int w, int gem)
    {
        if (g <= gold && w <= wood && gem <= gems)
        {
            gold -= g;
            wood -= w;
            gems -= gem;
            return true;
        }
        return false;
    }

    void Update()
    {
        goldText.text = gold.ToString();
        woodText.text = wood.ToString();
        gemsText.text = gems.ToString();

        //waveNum++;
        waveText.text = "Wave: " + waveNum.ToString() + "/" + totalWaves.ToString();
    }

    public static void IncreaseWave()
    {

        
    }


    public void LoadData()
    {
        //SceneManager.LoadScene("Main Scene");
        SaveData data = SaveSystem.LoadData();
         currentLives = data.lives;
         wood = data.woods;
         gold = data.gold;
         gems = data.gems;
         waveNum = data.waveNum;
         lives.GetComponent<PlayerLives>().loadCurrentLives(currentLives);
        Debug.Log("Data loaded from file. Lives = " + currentLives +
            "    Gold: " + gold +
            "    Gems: " + gems +
            "    Wood: " + wood +
            "    Wave number: " + waveNum);

    }
}

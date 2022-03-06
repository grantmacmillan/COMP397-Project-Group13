using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public TextMeshProUGUI goldText, woodText, gemsText, waveText;
    public static int gold, wood, gems, waveNum, totalWaves;
    public int startingGold = 999, startingWood = 999, startingGems = 999;

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
}

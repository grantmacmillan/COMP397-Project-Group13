using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveData 
{
    [SerializeField]
    private GameObject life;
    [SerializeField]
    private GameObject wood;
    public int lives;
    public int woods, gold, gems, waveNum;


    public SaveData(GameObject life)
    {
        lives = life.GetComponentInChildren<PlayerLives>().getCurrentLives();
        woods = ResourceManager.wood;
        gold = ResourceManager.gold;
        gems = ResourceManager.gems;
        waveNum = ResourceManager.waveNum;
    }
}

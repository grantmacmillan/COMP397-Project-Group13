using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class SaveData 
{
    public int lives;
    public int woods, gold, gems, waveNum;

    public string turretName;

    //Turret Information
    public float[] turretPosition;

    public SaveData(GameObject life) {
        lives = life.GetComponentInChildren<PlayerLives>().getCurrentLives();
        woods = ResourceManager.wood;
        gold = ResourceManager.gold;
        gems = ResourceManager.gems;
        waveNum = ResourceManager.waveNum;
    }
}

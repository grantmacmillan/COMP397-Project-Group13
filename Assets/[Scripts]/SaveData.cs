using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveData:MonoBehaviour 
{
    [SerializeField]
    private GameObject life;
    [SerializeField]
    private GameObject wood;
    public int lives;
    public int woods,gold, gems;
    


public SaveData(GameObject life)
    {
        lives = life.GetComponentInChildren<PlayerLives>().getCurrentLives();
        woods = ResourceManager.wood;
        gold = ResourceManager.gold;
        gems = ResourceManager.gems;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public Data activeSave;
    public bool hasLoaded;

    //Singleton
    private void Awake()
    {
        instance = this;
        this.activeSave.saveName = PlayerPrefs.GetString("Save Name");
        Debug.Log("Active Save Name: " + this.activeSave.saveName);

        if (PlayerPrefs.GetInt("Has Loaded") == 1)
            Load();

        if (PlayerPrefs.GetInt("Has Loaded") == 0)
            ResetData();
    }

    //Saving a game state
    public void Save()
    {
        string pathName = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(Data));
        var stream = new FileStream(pathName + "\\" + activeSave.saveName + ".txt", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();
    }

    //Loading a game state
    public void Load()
    {
        string pathName = Application.persistentDataPath;

        if (File.Exists(pathName + "\\" + activeSave.saveName + ".txt"))
        {
            var serializer = new XmlSerializer(typeof(Data));
            var stream = new FileStream(pathName + "\\" + activeSave.saveName + ".txt", FileMode.Open);

            activeSave = serializer.Deserialize(stream) as Data;
            stream.Close();

            hasLoaded = true;
        }
    }

    public void ResetData()
    {
        string pathName = Application.persistentDataPath;

        if (File.Exists(pathName + "\\" + activeSave.saveName + ".txt"))
        {
            hasLoaded = false;
        }
    }
}

[System.Serializable]
public class Data
{
    //Game name
    public string saveName;

    //Temporary gold checkpoint
    public int tempGold;
    public int tempWood;
    public int tempGem;


    //Resource information
    public int woodAmount;
    public int gemAmount;
    public int goldAmount;
    public int waveNumber;
    public int livesAmount;

    //Tower counts
    public int cannonCount;
    public int balistaCount;
    public int blasterCount;
    public int woodTowerCount;
    public int gemTowerCount;

    public int tempCannonCount;
    public int tempBalistaCount;
    public int tempBlasterCount;
    public int tempWoodTowerCount;
    public int tempGemTowerCount;

    //Tower Positions
    public List<float> cannonPositions;
    public List<float> balistaPositions;
    public List<float> blasterPositions;
    public List<float> woodTowerPositions;
    public List<float> gemTowerPositions;

    //Temp towers
    public List<float> tempCannonPositions;
    public List<float> tempBalistaPositions;
    public List<float> tempBlasterPositions;
    public List<float> tempWoodTowerPositions;
    public List<float> tempGemTowerPositions;
}
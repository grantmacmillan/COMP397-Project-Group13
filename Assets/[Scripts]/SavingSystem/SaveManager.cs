using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public Data activeSave;
    public bool hasLoaded;
    public AchievementSystem achievementSystem;

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
        if (GameObject.FindGameObjectWithTag("achievement") != null)
        {
            achievementSystem = GameObject.FindGameObjectWithTag("achievement").GetComponent<AchievementSystem>();
        }
        LoadGlobalData();
    }

    //Saving a game state
    public void Save()
    {
        string pathName = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(Data));
        var stream = new FileStream(pathName + "/global_save_data/" + activeSave.saveName + ".txt", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();
    }

    //Loading a game state
    public void Load()
    {
        string pathName = Application.persistentDataPath;

        if (File.Exists(pathName + "/global_save_data/" + activeSave.saveName + ".txt"))
        {
            var serializer = new XmlSerializer(typeof(Data));
            var stream = new FileStream(pathName + "/global_save_data/" + activeSave.saveName + ".txt", FileMode.Open);

            activeSave = serializer.Deserialize(stream) as Data;
            stream.Close();

            hasLoaded = true;
        }
    }

    public void ResetData()
    {
        string pathName = Application.persistentDataPath;

        if (File.Exists(pathName + "/global_save_data/" + activeSave.saveName + ".txt"))
        {
            hasLoaded = false;
        }
    }
    //Global Save Data

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            string pathName = Application.persistentDataPath;
            if (!Directory.Exists(pathName + "/global_save_data"))
            {
                Directory.CreateDirectory(pathName + "/global_save_data");
            }

            BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Create(pathName + "/global_save_data/save.json");
            var json = JsonUtility.ToJson(achievementSystem);
            File.WriteAllText(pathName + "/global_save_data/save.json", json);
            //bf.Serialize(file, json);
            //file.Close();
        }
    }

    void LoadGlobalData()
    {
        string saveFile = Application.persistentDataPath + "/global_save_data/save.json";
        if (File.Exists(saveFile))
        {
            //FileStream file = File.Open(saveFile, FileMode.Open);
            JsonUtility.FromJsonOverwrite(File.ReadAllText(saveFile), achievementSystem);
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

    public int currentQuest;
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
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
    private void Awake() {
        instance = this;
        Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Save();
        if (Input.GetKeyDown(KeyCode.M))
            Load();
    }

    //Saving a game state
    public void Save() {
        string pathName = Directory.GetCurrentDirectory();
        string dataPath = pathName + "\\Assets\\Data";

        var serializer = new XmlSerializer(typeof(Data));
        var stream = new FileStream(dataPath + "\\" + activeSave.saveName + ".txt", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Saved");
    }

    //Loading a game state
    public void Load() {
        string pathName = Directory.GetCurrentDirectory();
        string dataPath = pathName + "\\Assets\\Data";

        if (File.Exists(dataPath + "\\" + activeSave.saveName + ".txt")) {
            var serializer = new XmlSerializer(typeof(Data));
            var stream = new FileStream(dataPath + "\\" + activeSave.saveName + ".txt", FileMode.Open);

            activeSave = serializer.Deserialize(stream) as Data;
            stream.Close();

            hasLoaded = true;
            Debug.Log("Loaded");
        }
    }
}

[System.Serializable]
public class Data {
    //Game name
    public string saveName;

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

    //Tower Positions
    public List<float> cannonPositions;
    public List<float> balistaPositions;
    public List<float> blasterPositions;
    public List<float> woodTowerPositions;
    public List<float> gemTowerPositions;
}
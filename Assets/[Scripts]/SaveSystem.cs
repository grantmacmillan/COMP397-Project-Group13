using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class SaveSystem 
{
#if UNITY_ANDROID && !UNITY_EDITOR
path =path.Combine(Application.persistentDataPath,"Save.json");
#else


#endif
    public static bool hasLoaded;
    public const string subFile = "\\Data";
    public static void SaveData(GameObject life) {
        string path = Path.Combine(Application.dataPath + subFile, "Save.json");
        SaveData data = new SaveData(life);
        File.WriteAllText(path, JsonUtility.ToJson(data));

        //Debugging
        Debug.Log("Data saved in file. Lives = " + data.lives+
            "    Gold: " + data.gold +
            "    Gems: " + data.gems +
            "    Wood: "+ data.woods +
            "    Wave number: " + data.waveNum);
    }

    public static SaveData LoadData() {
        string path = Path.Combine(Application.dataPath + subFile, "Save.json");
        Debug.Log(path);
        if (File.Exists(path)) {
            SaveData loadData = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
        
            //Debugging
            Debug.Log("Data loaded from file. Lives = " + loadData.lives +
            "    Gold: " + loadData.gold +
            "    Gems: " + loadData.gems +
            "    Wood: " + loadData.woods +
            "    Wave number: " + loadData.waveNum);

            hasLoaded = true;
            return loadData;
        }
        else {
            Debug.LogError("Save file not found");
            hasLoaded = false;
            return null;
        }
    }
}


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
    public static void SaveData(GameObject life)
    {
        string path = Path.Combine(Application.dataPath, "Save.json");
        SaveData data = new SaveData(life);
        File.WriteAllText(path, JsonUtility.ToJson(data));
        Debug.Log("Data saved in file. Lives = " + data.lives+
            "    Gold: " + data.gold +
            "    Gems: " + data.gems +
            "    Wood: "+ data.woods +
            "    Wave number: " + data.waveNum);
    }

    public static SaveData LoadData()
    {       
        string path = Path.Combine(Application.dataPath, "Save.json");
        Debug.Log(path);
        if (File.Exists(path))
        {
            
            SaveData loadData = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
        
            Debug.Log("Data loaded from file. Lives = " + loadData.lives +
            "    Gold: " + loadData.gold +
            "    Gems: " + loadData.gems +
            "    Wood: " + loadData.woods +
            "    Wave number: " + loadData.waveNum);
            return loadData;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }
}


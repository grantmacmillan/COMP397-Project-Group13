using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class SaveSystem 
{
    public static void SaveData(GameObject life, GameObject wood)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
path =path.Combine(Application.persistentDataPath,"Save.json");
#else
    string path = Path.Combine(Application.dataPath, "Save.json");
     
#endif
        SaveData data = new SaveData(life,wood);
        File.WriteAllText(path, JsonUtility.ToJson(data));
        Debug.Log("Data saved in file. Lives = " + data.lives+
            "\nWood: "+data.woods);
    }

}


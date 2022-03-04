using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class SaveSystem 
{

    public static void SaveData(GameObject gobj)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
path =path.Combine(Application.persistentDataPath,"Save.json");
#else
    string path = Path.Combine(Application.dataPath, "Save.json");
     //   string path = Path.Combine("E:\\COLLEGE\\Semester_4\\Game_Web\\TowerDefense", "Save.json");
#endif
        SaveData data = new SaveData(gobj);
        File.WriteAllText(path, JsonUtility.ToJson(data));
        Debug.Log("Lives:" + data.lives);
    }





    /*
    [SerializeField]
    private GameObject gobj;

    private Save save = new Save(gobj);
    private string path;
   
   
    private string jsonData = "Random Text";
    //private ObjToSave obj = new ObjToSave();

    private void JsonSave()
    {
        JsonUtility.ToJson(obj);
    }

    private void JsonLoad()
    {
        obj = JsonUtility.FromJson<ObjToSave>(jsonData);
    }
   

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
path =path.Combine(Application.persistentDataPath,"Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            Debug.Log("Lives:"+ save.lives);
        }
    }

    private void OnApplicationQuit()    {
        File.WriteAllText(path, JsonUtility.ToJson(save));
        Debug.Log("Lives:"+ save.lives);
        
    }*/
}


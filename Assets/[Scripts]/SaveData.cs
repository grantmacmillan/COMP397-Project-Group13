using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData:MonoBehaviour 
{
    [SerializeField]
    private GameObject gobj;
    public int lives;

    public SaveData(GameObject gobj)
    {
        lives = gobj.GetComponent<PlayerLives>().getCurrentLives();
        
    }
}

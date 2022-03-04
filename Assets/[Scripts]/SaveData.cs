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
    public string woods;
    


public SaveData(GameObject life, GameObject wood)
    {
        lives = life.GetComponentInChildren<PlayerLives>().getCurrentLives();

        //temporary access the text field. Needs to be replaced by actual data from the script
        woods = wood.GetComponent<TextMeshProUGUI>().text;        
    }
}

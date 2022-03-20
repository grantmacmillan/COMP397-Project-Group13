using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

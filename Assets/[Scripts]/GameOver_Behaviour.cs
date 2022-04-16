using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Behaviour : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI, loadMenuUI;
    [SerializeField]
    private GameObject life;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        loadMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void LoadMenu(){
        // SceneManager.LoadScene("Load Menu");
         pauseMenuUI.SetActive(false);
        loadMenuUI.SetActive(true);
        

    }

    public void SaveMenu(){
        SaveSystem.SaveData(life);
    }

    public void ExitToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

}

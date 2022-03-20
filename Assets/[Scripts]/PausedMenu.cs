using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenu, loadMenu;
    [SerializeField] private GameObject life;

    //Finds the pause panel
    void Start() {
        pauseMenu.SetActive(false);
        loadMenu.SetActive(false);
    }

    void Update()
    {
        //Checks if the game is paused
        if (Input.GetKeyDown(KeyCode.P))
            if (GameIsPaused)
                Resume();
            else
                Pause();
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        loadMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause() {
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenu.SetActive(true);
    }

    public void LoadMenu() {
        //pauseMenu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public void SaveMenu() {
        SaveManager.instance.Save();
    }

    public void ExitToMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameManager : MonoBehaviour
{
    public void NewGameOne() {
        PlayerPrefs.SetString("Save Name", "Game1");
        PlayerPrefs.SetInt("Has Loaded", 0);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Debug.Log("Resetting and Deleting Game 1");
    }

    public void NewGameTwo() {
        PlayerPrefs.SetString("Save Name", "Game2");
        PlayerPrefs.SetInt("Has Loaded", 0);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void NewGameThree() {
        PlayerPrefs.SetString("Save Name", "Game3");
        PlayerPrefs.SetInt("Has Loaded", 0);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void LoadGameOne() {
        PlayerPrefs.SetString("Save Name", "Game1");
        PlayerPrefs.SetInt("Has Loaded", 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void LoadGameTwo() {
        PlayerPrefs.SetString("Save Name", "Game2");
        PlayerPrefs.SetInt("Has Loaded", 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void LoadGameThree() {
        PlayerPrefs.SetString("Save Name", "Game3");
        PlayerPrefs.SetInt("Has Loaded", 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void BackButton_Pressed() {
        this.gameObject.SetActive(false);
    }
}

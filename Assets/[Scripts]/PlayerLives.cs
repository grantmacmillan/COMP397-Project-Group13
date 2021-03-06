using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxLives = 5;
     public static int currentLives;

    public TextMeshProUGUI livesText;

    void Start()
    {
        currentLives = maxLives;
        livesText = GetComponent<TextMeshProUGUI>();
        //livesText.text = "C";
        //Debug.Log(currentLives);
        livesText.text = currentLives.ToString();
    }

    public void LoseLife(int lives)
    {
        //Debug.Log("lost a life");
        currentLives--;
        //Debug.Log(currentLives);
        livesText.text = currentLives.ToString();

        //change UI

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public int getCurrentLives()
    {
       return currentLives;
    }

    public void loadCurrentLives(int lives)
    {
        //Debug.Log("Call Current lives function");
        currentLives =lives;
        livesText.text = currentLives.ToString();
    }
}

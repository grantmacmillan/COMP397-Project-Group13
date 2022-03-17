using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject newGameMenu;
    void Start() {
        newGameMenu = GameObject.Find("New Game Menu");
        newGameMenu.SetActive(false);
    }

    // Start is called before the first frame update
    public void update()
    {
        FindObjectOfType<Sound_Manager>().Play("MenuSelect");
    }
    public void NewGame()
    {
        //SceneManager.LoadScene(1);
        //Time.timeScale = 1f;
        newGameMenu.SetActive(true);

    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

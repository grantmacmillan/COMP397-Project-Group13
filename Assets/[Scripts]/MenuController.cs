using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void update()
    {
        FindObjectOfType<Sound_Manager>().Play("MenuSelect");
    }
    public void NewGame()
    {
        
        SceneManager.LoadScene(1);
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Next level to load")]
    public string levelToLoad = "LevelOne";

    public GameObject ui;

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene (levelToLoad);
    }

    public void SelectLevel()
    {
        Debug.Log("select");
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}

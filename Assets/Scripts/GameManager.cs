using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsEnded;

    public static string menuToLoad;

    [Header("Main menu of game")]
    public string mainMenu;

    [Header("UI when lose or win")]
    public GameObject gameOverUI;

    public GameObject finishLevelUI;

    void Start()
    {
        gameIsEnded = false;
        menuToLoad = mainMenu;
    }

    void Update()
    {
        if (gameIsEnded)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    public void WinLevel()
    {
        finishLevelUI.SetActive(true);
    }

    void EndGame()
    {
        Time.timeScale = 0f;
        gameIsEnded = true;
        gameOverUI.SetActive(true);
    }
}

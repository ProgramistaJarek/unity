using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [Header("First level in our game")]
    public string levelFirst;

    public void Menu()
    {
        SceneManager.LoadScene(GameManager.menuToLoad);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene (levelFirst);
    }
}

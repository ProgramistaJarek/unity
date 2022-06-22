using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextLevel;

    public void Next()
    {
        SceneManager.LoadScene (nextLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene(GameManager.menuToLoad);
    }
}

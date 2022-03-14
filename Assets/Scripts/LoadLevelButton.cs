using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    public void LoadLevel()
    {
        if (GameManager.LevelIndex == GameManager.EndLevelIndex)
        {
            SceneManager.LoadScene($"Win");
        }
        SceneManager.LoadScene($"Level{GameManager.LevelIndex + 1}");
    }
}

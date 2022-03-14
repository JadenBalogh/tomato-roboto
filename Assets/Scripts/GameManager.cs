using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private int endLevel = 3;
    public static int EndLevelIndex { get => instance.endLevel; }

    public static int LevelIndex { get; private set; }
    public static bool IsGameOver { get; private set; }
    public static bool IsLevelOver { get; private set; }
    public static Player Player { get; private set; }
    public static float LevelDuration { get => instance.endTime - instance.startTime; }

    private float startTime = 0;
    private float endTime = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelIndex++;
        IsLevelOver = false;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startTime = Time.time;
        Time.timeScale = 1f;
    }

    public static void EndLevel() => instance.IEndLevel();
    private void IEndLevel()
    {
        if (IsLevelOver) return;

        IsLevelOver = true;
        endTime = Time.time;
        Time.timeScale = 0f;
        HUD.DisplayEndScreen();
    }

    public static void EndGame(bool won) => instance.IEndGame(won);
    private void IEndGame(bool won)
    {
        if (IsGameOver || IsLevelOver) return;

        IsGameOver = true;
        IsLevelOver = true;
        endTime = Time.time;
        Time.timeScale = 0f;
        HUD.DisplayDeathScreen();
    }
}

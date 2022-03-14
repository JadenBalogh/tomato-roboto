using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HUD : MonoBehaviour
{
    private static HUD instance;

    [Header("End Panel")]
    [SerializeField] private CanvasGroup endLevelPanel;
    [SerializeField] private TextMeshProUGUI endTitleText;
    [SerializeField] private TextMeshProUGUI endTimeText;

    [Header("Death Panel")]
    [SerializeField] private CanvasGroup deathPanel;
    [SerializeField] private TextMeshProUGUI deathTimeText;

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
        EnablePanel(endLevelPanel, false);
        EnablePanel(deathPanel, false);
    }

    public static void DisplayEndScreen() => instance.IDisplayEndScreen();
    private void IDisplayEndScreen()
    {
        endTitleText.text = $"Level {GameManager.LevelIndex} Complete!";
        endTimeText.text = $"Time Spent: {GameManager.LevelDuration.ToString("#.##")}s";
        EnablePanel(endLevelPanel, true);
    }

    public static void DisplayDeathScreen() => instance.IDisplayDeathScreen();
    private void IDisplayDeathScreen()
    {
        deathTimeText.text = $"Time Spent: {GameManager.LevelDuration.ToString("#.##")}s";
        EnablePanel(deathPanel, true);
    }

    private void EnablePanel(CanvasGroup panel, bool enabled)
    {
        panel.alpha = enabled ? 1f : 0f;
        panel.interactable = enabled;
        panel.blocksRaycasts = enabled;
    }
}

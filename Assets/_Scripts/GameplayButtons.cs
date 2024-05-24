using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText; 
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private GameObject _tutorial;
    public static int Coins;

    private void Start()
    {
        Time.timeScale = 1;
        Coins = PlayerPrefs.GetInt("coinsCount", 0);
        _bestScoreText.text = "BEST: " + PlayerPrefs.GetInt("bestScore", 0).ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void Update()
    {
        _coinsText.text = Coins.ToString();
    }

    public void OpenTutorial()
    {
        _tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        _tutorial.SetActive(false);
    }
}

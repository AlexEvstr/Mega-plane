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

    [SerializeField] private GameObject _onboard_1;
    [SerializeField] private GameObject _onboard_2;
    [SerializeField] private GameObject _onboard_3;
    public static int Coins;

    private void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.Portrait;
        string onboard = PlayerPrefs.GetString("onBoard", "");
        if (onboard == "")
        {
            _onboard_1.SetActive(true);
        }
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

    public void OpenSecond()
    {
        _onboard_1.SetActive(false);
        _onboard_2.SetActive(true);
    }

    public void OpenThird()
    {
        _onboard_2.SetActive(false);
        _onboard_3.SetActive(true);
    }

    public void OpenGame()
    {
        _onboard_3.SetActive(false);
        PlayerPrefs.SetString("onBoard", "nope");
    }
}

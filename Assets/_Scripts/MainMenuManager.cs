using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText; 
    public static int Coins;

    private void Start()
    {
        Time.timeScale = 1;
        Coins = PlayerPrefs.GetInt("coinsCount", 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void Update()
    {
        _coinsText.text = Coins.ToString();
    }
}

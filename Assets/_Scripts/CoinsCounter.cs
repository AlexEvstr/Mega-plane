using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _cointText;
    private GameAudioController _gameAudioController;
    private int _coins;

    private void Start()
    {
        _gameAudioController = GetComponent<GameAudioController>();
        _coins = PlayerPrefs.GetInt("coinsCount", 0);
        _cointText.text = _coins.ToString();
    }

    public void IncreaseCoinsCount()
    {
        _coins++;
        _gameAudioController.CoinSound();
        PlayerPrefs.SetInt("coinsCount", _coins);
        _cointText.text = _coins.ToString();
    }
}

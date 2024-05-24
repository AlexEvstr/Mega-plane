using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestloseText;
    [SerializeField] private TMP_Text _bestPauseText;
    [SerializeField] private GameObject _plane;
    private int _score;
    private int _bestScore;

    private void Start()
    {
        PlayerPrefs.GetInt("scoreCount", 0);
        _bestScore = PlayerPrefs.GetInt("bestScore", 0);
        StartCoroutine(ScoreIncrease());
    }

    private IEnumerator ScoreIncrease()
    {
        while(_plane != null)
        {
            _score++;
            _scoreText.text = _score.ToString();
            
            if (_bestScore < _score)
            {
                _bestScore = _score;
                PlayerPrefs.SetInt("bestScore", _bestScore);
            }
            _bestloseText.text = $"BEST: {_bestScore}";
            _bestPauseText.text = $"BEST: {_bestScore}";

            yield return new WaitForSeconds(0.1f);
        }
    }
}

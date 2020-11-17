using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] HighScoreManager highScoreManager = null;
    [SerializeField] private TextMeshProUGUI _currentScore = null;
    [SerializeField] private TextMeshProUGUI _finalScore = null;
    [SerializeField] private TextMeshProUGUI _highScore = null;
    private float _score;
    void Update()
    {
        if (!GameOver.Instance.IsGameOver)
        {
            _score += Time.deltaTime;
            _currentScore.text = Mathf.RoundToInt(_score).ToString();
        }
        else
        {
            if (highScoreManager.HighScore < Mathf.RoundToInt(_score))
            {
                highScoreManager.HighScore = Mathf.RoundToInt(_score);
            }
            _finalScore.text = "Score: " + Mathf.RoundToInt(_score);
            _highScore.text = "High Score: " + highScoreManager.HighScore;
        }
    }
}

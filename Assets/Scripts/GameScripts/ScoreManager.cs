using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] HighScoreManager highScoreManager;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _finalScore;
    [SerializeField] private TextMeshProUGUI _highScore;
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

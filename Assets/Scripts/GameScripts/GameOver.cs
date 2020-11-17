using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private static GameOver _instance;
    public static GameOver Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameOver>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameOver");
                    _instance = container.AddComponent<GameOver>();
                }
            }
            return _instance;
        }
    }
    [SerializeField] private Animator _gameOverPanel = null;
    public bool IsGameOver;
    void Update()
    {
        if (IsGameOver)
        {
            _gameOverPanel.SetBool("isGameOver", true);
        }
    }
}

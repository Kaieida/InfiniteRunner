using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Animator _gameOverPanel;
    public bool IsGameOver;
    void Start()
    {
        _gameOverPanel = GameObject.Find("Panel").GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameOverPanel.SetBool("isGameOver", true);
            IsGameOver = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

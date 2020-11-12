using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    private float _score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _score += Time.deltaTime;
        _currentScore.text = Mathf.RoundToInt(_score).ToString();
    }
}

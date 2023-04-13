using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;

    public Transform gameOverPanel;
    public Text scoreText;

    private int _currentScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDead()
    {
        isGameOver = true;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void OnOverObstacle()
    {
        Debug.Log("OnOverObstacle");
        _currentScore += 10;
        scoreText.text = $"Score:{_currentScore}";
    }
}

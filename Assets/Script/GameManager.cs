﻿using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.UI;
using XLua;
[Hotfix]
[LuaCallCSharp]
public class GameManager : MonoBehaviour
{
    [LuaCallCSharp]
    public static GameManager Instance;
    [LuaCallCSharp]
    public bool isGameOver = false;

    private LuaTool _luaTool;
    
    public Transform gameOverPanel;
    public Text scoreText;

    public Button restartBtn;
    private int _currentScore = 0;

    public StrollBackGround strollBackGround;
    public SpawnObstacle spawnObstacle;

    private void Awake()
    {
        Instance = this;
     
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentScore = 0;
         _luaTool = new LuaTool();
        //engage hot update
        _luaTool.DoString("GameControllerUpdate");
        _luaTool.DoString("ResourceUpdate");
        _luaTool.DoString("AudioControlUpdate");
        
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

    private void OnDestroy()
    {
        _luaTool.DoString("Dispose");
    }
}

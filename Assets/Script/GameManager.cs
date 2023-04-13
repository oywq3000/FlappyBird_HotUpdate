using System;
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
        LuaTool luaTool = new LuaTool();
        //engage hot update
        luaTool.DoString("GameControllerUpdate");
        luaTool.DoString("ResourceUpdate");
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
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public Canvas rootCanvas;
    private Text scoreText;
    private int score;

    void Start()
    {
        rootCanvas = GetComponentInParent<Canvas>();
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(rootCanvas);
        scoreText = GetComponent<Text>();
    }

    public void SetScore(int points)
    {
        score = points;
        DrawScore(score.ToString());
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        DrawScore(score.ToString());
    }

    public void IncreaseScore(int points)
    {
        score += points;
        DrawScore(score.ToString());
    }

    private void DrawScore(string text)
    {
        scoreText.text = text;
    }

    public void GameOverTextReset()
    {
        var gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        gameOver.text = "";
    }
}
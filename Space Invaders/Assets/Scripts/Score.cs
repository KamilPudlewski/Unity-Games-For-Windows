using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private int score;

    void Start()
    {
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
}

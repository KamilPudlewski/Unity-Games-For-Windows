using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public int score = 0;
    public int destructionScore = 0;
    private bool countScore = true;

    void Start()
    {

    }

    void Update()
    {
        if (countScore)
        {
            score += 1;
        }
    }

    public void AddDestructionPoints(int points)
    {
        destructionScore += points;
    }

    public void StopCountScore()
    {
        countScore = false;
    }

    public int ReturnScore()
    {
        return (score / 10) + destructionScore;
    }
}

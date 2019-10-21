using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            DestroyBullets();
            RestartScene();
            DestroyBullets();
        }

        if (!CheckOpponents())
        {
            int score = GetScorePoints();
            RestartScene();
            DestroyBullets();
            SetScorePoints(score);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DestroyBullets()
    {
        GameObject[] bullets;
        bullets = GameObject.FindGameObjectsWithTag("AlienBullet");

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    private bool CheckOpponents()
    {
        GameObject[] aliens;
        aliens = GameObject.FindGameObjectsWithTag("Alien" );

        if (aliens.Length != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int GetScorePoints()
    {
        Score score = GameObject.Find("Score").GetComponent<Score>();
        return score.GetScore();
    }

    private void SetScorePoints(int points)
    {
        Score score = GameObject.Find("Score").GetComponent<Score>();
        score.SetScore(points);
    }
}

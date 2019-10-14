using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    GameObject[] bullets;
    GameObject[] aliens;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
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

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DestroyBullets()
    {
        bullets = GameObject.FindGameObjectsWithTag("AlienBullet");

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        Debug.Log(bullets.Length);
    }

    bool CheckOpponents()
    {
        aliens = GameObject.FindGameObjectsWithTag("Alien");

        if (aliens.Length != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    int GetScorePoints()
    {
        var score = GameObject.Find("Score").GetComponent<Text>();
        return Int32.Parse(score.text);
    }

    void SetScorePoints(int points)
    {
        var score = GameObject.Find("Score").GetComponent<Text>();
        score.text = points.ToString();
    }
}

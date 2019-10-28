using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;
    private int bulletClearStatus = 0;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown("r"))
        {
            gameReset();
        }

        DestroyAlienBulletsAfterSceneRestart();
        RestartAfterCompleteLevel();
    }

    public void gameReset()
    {
        RestartScene();
        Score.Instance.ResetScore();
        Score.Instance.GameOverTextReset();
        bulletClearStatus++;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DestroyAlienBulletsAfterSceneRestart()
    {
        if (bulletClearStatus != 0)
        {
            DestroyBullets();
            bulletClearStatus++;

            if (bulletClearStatus == 100)
            {
                bulletClearStatus = 0;
            }
        }
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

    private void RestartAfterCompleteLevel()
    {
        if (!CheckOpponents())
        {
            RestartScene();
            bulletClearStatus++;
        }
    }

    private bool CheckOpponents()
    {
        GameObject[] aliens;
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
}

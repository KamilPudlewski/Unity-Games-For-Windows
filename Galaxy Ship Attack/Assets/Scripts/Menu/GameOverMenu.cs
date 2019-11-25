using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text score;
    public Text totalScore;

    void Start()
    {
        LoadScore();
        LoadTotalScore();
    }

    private void LoadScore()
    {
        score.text = "Points earned: " + PlayerPrefs.GetInt("Score").ToString();
    }

    private void LoadTotalScore()
    {
        int newTotalScore = PlayerPrefs.GetInt("TotalScore") + PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("TotalScore", newTotalScore);
        totalScore.text = "Total points: " + newTotalScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void OpenUpgradeMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public Text totalPoints;
    public Image spaceship;
    public Text price;
    public Text buy;

    public Sprite[] spaceshipSprites;
    public int[] spaceshipPrices;

    private int spaceshipSkin = 0;

    void Start()
    {
        //ResetGameStatus();
        UpdateUI();
    }

    public void UndoSpaceship()
    {
        DecreaseSkinNumber();
        ChangeSpaceshipSkin(spaceshipSkin);
        UpdatePrice();
        UpdateBuyButton();
    }

    public void NextSpaceship()
    {
        IncreaseSkinNumber();
        ChangeSpaceshipSkin(spaceshipSkin);
        UpdatePrice();
        UpdateBuyButton();
    }

    public void Buy()
    {
        if (PlayerPrefs.GetInt("Spaceship" + spaceshipSkin) == 1)
        {
            PlayerPrefs.SetInt("SelectedSpaceship", spaceshipSkin);
            UpdateUI();
        }
        else
        {
            BuySpaceship();
        }
    }

    private void BuySpaceship()
    {
        if (PlayerPrefs.GetInt("Spaceship" + spaceshipSkin) == 0)
        {
            if (PlayerPrefs.GetInt("TotalScore") >= spaceshipPrices[spaceshipSkin])
            {
                int pointsAfterBuy = PlayerPrefs.GetInt("TotalScore") - spaceshipPrices[spaceshipSkin];
                PlayerPrefs.SetInt("TotalScore", pointsAfterBuy);
                PlayerPrefs.SetInt("Spaceship" + spaceshipSkin, 1);
                PlayerPrefs.SetInt("SelectedSpaceship", spaceshipSkin);
                UpdateUI();
            }
        }
    }

    private void IncreaseSkinNumber()
    {
        if (spaceshipSkin < spaceshipSprites.Length - 1)
        {
            spaceshipSkin++;
        }
        else
        {
            spaceshipSkin = 0;
        }
    }

    private void DecreaseSkinNumber()
    {
        if (spaceshipSkin > 0)
        {
            spaceshipSkin--;
        }
        else
        {
            spaceshipSkin = spaceshipSprites.Length - 1;
        }
    }
    
    private void ChangeSpaceshipSkin(int skin)
    {
        spaceshipSkin = skin;
        spaceship.sprite = spaceshipSprites[spaceshipSkin];
    }

    private void UpdateUI()
    {
        UpdateTotalPoints();
        UpdatePrice();
        UpdateBuyButton();
    }

    private void UpdateTotalPoints()
    {
        totalPoints.text = "Total points: " + PlayerPrefs.GetInt("TotalScore").ToString();
    }

    private void UpdatePrice()
    {
        if (spaceshipSkin == PlayerPrefs.GetInt("SelectedSpaceship"))
        {
            price.text = "Selected";
        }
        else if (PlayerPrefs.GetInt("Spaceship" + spaceshipSkin) == 1)
        {
            price.text = "Owned";
        }
        else
        {
            price.text = "Price: " + spaceshipPrices[spaceshipSkin].ToString();
        }   
    }

    private void UpdateBuyButton()
    {
        if (spaceshipSkin == PlayerPrefs.GetInt("SelectedSpaceship"))
        {
            buy.text = "SELECT";
        }
        else if (PlayerPrefs.GetInt("Spaceship" + spaceshipSkin) == 1)
        {
            buy.text = "SELECT";
        }
        else
        {
            buy.text = "BUY";
        }
    }

    private void ResetGameStatus()
    {
        PlayerPrefs.SetInt("Spaceship0", 1);
        PlayerPrefs.SetInt("Spaceship1", 0);
        PlayerPrefs.SetInt("Spaceship2", 0);
        PlayerPrefs.SetInt("Spaceship3", 0);
        PlayerPrefs.SetInt("Spaceship4", 0);
        PlayerPrefs.SetInt("SelectedSpaceship", 0);
        PlayerPrefs.SetInt("TotalScore", 0);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
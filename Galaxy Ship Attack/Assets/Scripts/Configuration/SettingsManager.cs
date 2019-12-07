using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SettingsManager : ScriptableObject
{
    public Settings settings = new Settings();

    public SettingsManager()
    {
        LoadData();
    }

    public void SaveData()
    {
        if (!Directory.Exists("Configs"))
            Directory.CreateDirectory("Configs");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Configs/config.binary");

        formatter.Serialize(saveFile, settings);

        saveFile.Close();
    }

    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Configs/config.binary", FileMode.Open);

        settings = (Settings)formatter.Deserialize(saveFile);

        saveFile.Close();
    }

    public void LoadDataFromFile(string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open(path, FileMode.Open);
        
        settings = (Settings)formatter.Deserialize(saveFile);

        saveFile.Close();
    }

    public void ResetData()
    {
        ResetBalance();
        ResetScoring();
    }

    public void ResetBalance()
    {
        settings.spaceshipSpeed = 7f;
        settings.spaceshipReloadTimer = 0.5f;
        
        settings.adaptiveDifficultyLevel = true;
        settings.timerToSpawnEnemy = 2f;
        settings.minTimeToSpawn = 0.5f;
        settings.changeAfterSpawn = 4;
        settings.changeSteps = 15;

        settings.asteroid1Enable = true;
        settings.asteroid1Speed = 5f;
        settings.asteroid2Enable = true;
        settings.asteroid2Speed = 8f;
        settings.asteroid3Enable = true;
        settings.asteroid3Speed = 13f;

        settings.ospaceshipEnable = true;
        settings.ospaceshipSpeed = 5f;
        settings.enemySpaceshipSpawnChance = 40;
        settings.enemyAsteroidsSpawnChance = 60;

        settings.teslaEnable = true;
        settings.teslaSpeed = 10f;
        settings.teslaSpawnCounter = 15;
        settings.teslaSpawnChance = 75;
    }

    public void ResetScoring()
    {
        settings.asteroid1Points = 1;
        settings.asteroid2Points = 2;
        settings.asteroid3Points = 3;
        settings.ospaceshipPoints = 5;
        settings.teslaPoints = 100;
    }
}

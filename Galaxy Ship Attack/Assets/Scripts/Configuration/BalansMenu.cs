using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BalansMenu
{
    SettingsManager settingsManager;
    private static Texture2D asteroid1Texture = null;
    private static Texture2D asteroid2Texture = null;
    private static Texture2D asteroid3Texture = null;
    private static Texture2D ospaceshipTexture = null;
    private static Texture2D teslaTexture = null;

    public BalansMenu(SettingsManager settingsManager)
    {
        this.settingsManager = settingsManager;
        asteroid1Texture = (Texture2D)Resources.Load("Asteroid", typeof(Texture2D));
        asteroid2Texture = (Texture2D)Resources.Load("Asteroid 2", typeof(Texture2D));
        asteroid3Texture = (Texture2D)Resources.Load("Asteroid 3", typeof(Texture2D));
        ospaceshipTexture = (Texture2D)Resources.Load("Ospaceship", typeof(Texture2D));
        teslaTexture = (Texture2D)Resources.Load("Tesla", typeof(Texture2D));
    }

    public void View()
    {
        GUILayout.Label("Player Spaceship Settings", EditorStyles.boldLabel);
        settingsManager.settings.spaceshipSpeed = EditorGUILayout.Slider(new GUIContent("Spaceship Speed", "Player Spaceship Move And Down Moves Speed"), settingsManager.settings.spaceshipSpeed, 0.1f, 20f);
        settingsManager.settings.spaceshipReloadTimer = EditorGUILayout.Slider(new GUIContent("Spaceship Reload Time", "Spaceship Reload Time In Seconds"), settingsManager.settings.spaceshipReloadTimer, 0.1f, 2f);

        GUILayout.Label("Enemy Spawn", EditorStyles.boldLabel);
        settingsManager.settings.timerToSpawnEnemy = EditorGUILayout.Slider(new GUIContent("Time To Spawn Enemy", "Starting Time In Seconds Between Enemy Spawn"), settingsManager.settings.timerToSpawnEnemy, 0.1f, 10f);

        settingsManager.settings.adaptiveDifficultyLevel = EditorGUILayout.Toggle(new GUIContent("Adaptive Difficulty Level", "Enable Changing Difficulty Level"), settingsManager.settings.adaptiveDifficultyLevel);
        AdaptiveDifficultyLevelChange();
        GUILayout.Label("");

        GUILayout.Label("Enemy Types", EditorStyles.boldLabel);

        GUILayout.Label("Enemy Asteroids Settings", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(asteroid1Texture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.asteroid1Enable = EditorGUILayout.Toggle(new GUIContent("Enable Big Asteroids", "Enable Spawn Big Asteroids"), settingsManager.settings.asteroid1Enable);
        Asteroid1Change();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(asteroid2Texture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.asteroid2Enable = EditorGUILayout.Toggle(new GUIContent("Enable Middle Asteroids", "Enable Spawn Middle Asteroids"), settingsManager.settings.asteroid2Enable);
        Asteroid2Change();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(asteroid3Texture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.asteroid3Enable = EditorGUILayout.Toggle(new GUIContent("Enable Small Asteroids", "Enable Spawn Small Asteroids"), settingsManager.settings.asteroid3Enable);
        Asteroid3Change();
        EditorGUILayout.EndHorizontal();

        GUILayout.Label("Enemy Spaceship Settings", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(ospaceshipTexture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.ospaceshipEnable = EditorGUILayout.Toggle(new GUIContent("Enable Enemy Spaceships", "Enable Spawn Enemy Spaceships"), settingsManager.settings.ospaceshipEnable);
        SpaceshipChange();
        EditorGUILayout.EndHorizontal();
        SpaceshipSpawnChange();

        GUILayout.Label("Enemy Tesla Settings", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(teslaTexture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.teslaEnable = EditorGUILayout.Toggle(new GUIContent("Spawn Tesla", "Enable Spawn Tesla"), settingsManager.settings.teslaEnable);
        TeslaChange();
        EditorGUILayout.EndHorizontal();
        TeslaSpawnChage();
    }

    private void AdaptiveDifficultyLevelChange()
    {
        if (settingsManager.settings.adaptiveDifficultyLevel)
        {
            settingsManager.settings.minTimeToSpawn = EditorGUILayout.Slider(new GUIContent("Minimum Time To Spawn", "Minimum Enemy Spawm Time After Enable Hardest Difficulty"), settingsManager.settings.minTimeToSpawn, 0.1f, 5f);
            settingsManager.settings.changeSteps = EditorGUILayout.IntSlider(new GUIContent("Change Difficulty Steps", "Numbers Of Difficulty Change Steps"), settingsManager.settings.changeSteps, 1, 30);
            settingsManager.settings.changeAfterSpawn = EditorGUILayout.IntSlider(new GUIContent("Change Difficulty After Spawn", "Change Difficulty Step After Spawn {X} Enemy"), settingsManager.settings.changeAfterSpawn, 1, 20);
        }
    }

    private void Asteroid1Change()
    {
        if (settingsManager.settings.asteroid1Enable)
        {
            settingsManager.settings.asteroid1Speed = EditorGUILayout.Slider(new GUIContent("Big Asteroid Speed", "Big Asteroid Velocity"), settingsManager.settings.asteroid1Speed, 0.1f, 50f);
        }
    }

    private void Asteroid2Change()
    {
        if (settingsManager.settings.asteroid2Enable)
        {
            settingsManager.settings.asteroid2Speed = EditorGUILayout.Slider(new GUIContent("Middle Asteroid Speed", "Middle Asteroid Velocity"), settingsManager.settings.asteroid2Speed, 0.1f, 50f);
        }
    }

    private void Asteroid3Change()
    {
        if (settingsManager.settings.asteroid3Enable)
        {
            settingsManager.settings.asteroid3Speed = EditorGUILayout.Slider(new GUIContent("Small Asteroid Speed", "Small Asteroid Velocity"), settingsManager.settings.asteroid3Speed, 0.1f, 50f);
        }
    }

    private void SpaceshipChange()
    {
        if (settingsManager.settings.ospaceshipEnable)
        {
            settingsManager.settings.ospaceshipSpeed = EditorGUILayout.Slider(new GUIContent("Enemy Spaceship Speed", "Enemy Spaceship Velocity"), settingsManager.settings.ospaceshipSpeed, 0.1f, 50f);          
        }
    }

    private void SpaceshipSpawnChange()
    {
        if (settingsManager.settings.ospaceshipEnable)
        {
            settingsManager.settings.enemySpaceshipSpawnChance = EditorGUILayout.IntSlider(new GUIContent("Enemy Spaceship Spawn Chance", "Probability Of Creating A Ship Instead Of Ateroids"), settingsManager.settings.enemySpaceshipSpawnChance, 1, 100);
            settingsManager.settings.enemyAsteroidsSpawnChance = 100 - settingsManager.settings.enemySpaceshipSpawnChance;

            if (settingsManager.settings.enemySpaceshipSpawnChance == 100)
            {
                settingsManager.settings.asteroid1Enable = false;
                settingsManager.settings.asteroid2Enable = false;
                settingsManager.settings.asteroid3Enable = false;
            }
        }
        else
        {
            settingsManager.settings.enemyAsteroidsSpawnChance = 100;
        }
    }

    private void TeslaChange()
    {
        if (settingsManager.settings.teslaEnable)
        {
            settingsManager.settings.teslaSpeed = EditorGUILayout.Slider(new GUIContent("Tesla Move Speed", "Tesla Velocity"), settingsManager.settings.teslaSpeed, 0.1f, 50f);
        }
    }

    private void TeslaSpawnChage()
    {
        if (settingsManager.settings.teslaEnable)
        {
            settingsManager.settings.teslaSpawnCounter = EditorGUILayout.IntSlider(new GUIContent("Tesla Spawn After X Enemies", "Tesla Spawn After Spawn {X} Enemy"), settingsManager.settings.teslaSpawnCounter, 2, 60);
            settingsManager.settings.teslaSpawnChance = EditorGUILayout.IntSlider(new GUIContent("Tesla Spawn Chance", "Percentage Chance Spawn Tesla After Time To Spawn Up"), settingsManager.settings.teslaSpawnChance, 1, 100);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minY = -4.3f;
    public float maxY = 4.3f;

    public GameObject[] asteroidPrefabs; 
    public GameObject[] enemyPrefabs;
    public GameObject teslaPrefab;

    private SettingsManager settingsManager;
    private int spawnCount = 0;
    private int teslaSpawnCount = 0;
    private bool asteroidsEnabled = true;

    void Start()
    {
        settingsManager = ScriptableObject.CreateInstance("SettingsManager") as SettingsManager;
        asteroidsEnabled = AsteroidsEndabled();
        Invoke("SpawnEnemies", settingsManager.settings.timerToSpawnEnemy);
    }

    void Update()
    {
        AdaptiveDifficultyLevel();
    }

    private void SpawnEnemies()
    {
        float posY = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = posY;
        spawnCount++;
        teslaSpawnCount++;

        if (settingsManager.settings.teslaEnable && teslaSpawnCount == settingsManager.settings.teslaSpawnCounter)
        {
            if (Random.Range(0, 100) < settingsManager.settings.teslaSpawnChance)
            {
                Instantiate(teslaPrefab, temp, Quaternion.Euler(0f, 0f, 0f));
            }
            else
            {
                if (asteroidsEnabled)
                {
                    Instantiate(RandomAsteroidPrefab(), temp, Quaternion.identity);
                }
            }
            teslaSpawnCount = 0;
        }
        else
        {
            if (Random.Range(0, 100) > settingsManager.settings.enemyAsteroidsSpawnChance)
            {
                if (settingsManager.settings.ospaceshipEnable)
                {
                    Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], temp, Quaternion.Euler(0f, 0f, 0f));
                }
            }
            else
            {
                if (asteroidsEnabled)
                {
                    Instantiate(RandomAsteroidPrefab(), temp, Quaternion.identity);
                }
            }
        }
        Invoke("SpawnEnemies", settingsManager.settings.timerToSpawnEnemy);
    }

    private void AdaptiveDifficultyLevel()
    {
        if (settingsManager.settings.adaptiveDifficultyLevel)
        {
            if (spawnCount == settingsManager.settings.changeAfterSpawn)
            {
                spawnCount = 0;

                float newTimer = settingsManager.settings.timerToSpawnEnemy - (settingsManager.settings.timerToSpawnEnemy / settingsManager.settings.changeSteps);

                if (newTimer > settingsManager.settings.minTimeToSpawn)
                {
                    settingsManager.settings.timerToSpawnEnemy = newTimer;
                }
            }
        }
    }

    private GameObject RandomAsteroidPrefab()
    {
        List<int> asteroids = new List<int>();

        if (settingsManager.settings.asteroid1Enable)
        {
            asteroids.Add(0);
        }
        if (settingsManager.settings.asteroid2Enable)
        {
            asteroids.Add(1);
        }
        if (settingsManager.settings.asteroid3Enable)
        {
            asteroids.Add(2);
        }

        int index = asteroids[Random.Range(0, asteroids.Count)];
        return asteroidPrefabs[index];
    }

    private bool AsteroidsEndabled()
    {
        bool asteroidsEndabledStatus = false;
        
        if (settingsManager.settings.asteroid1Enable)
        {
            asteroidsEndabledStatus = true;
        }
        if (settingsManager.settings.asteroid2Enable)
        {
            asteroidsEndabledStatus = true;
        }
        if (settingsManager.settings.asteroid3Enable)
        {
            asteroidsEndabledStatus = true;
        }

        return asteroidsEndabledStatus;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minY = -4.3f;
    public float maxY = 4.3f;
    public bool adaptiveDifficultyLevel = true;

    public GameObject[] asteroidPrefabs;
    public GameObject enemyPrefab;

    public float timerToSpawnEnemy = 2f;
    public float minTimeToSpawn = 1f;
    public int changeAfterSppawnCount = 3;
    public float changeSteps = 10f;

    private int spawnCount = 0;

    void Start()
    {
        Invoke("SpawnEnemies", timerToSpawnEnemy);
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

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 0f));
        }
        Invoke("SpawnEnemies", timerToSpawnEnemy);
    }

    private void AdaptiveDifficultyLevel()
    {
        if (adaptiveDifficultyLevel)
        {
            if (spawnCount == changeAfterSppawnCount)
            {
                spawnCount = 0;
                float newTimer = timerToSpawnEnemy - (timerToSpawnEnemy / changeSteps);

                if (newTimer > minTimeToSpawn)
                {
                    timerToSpawnEnemy = newTimer;
                }
            }
        }
    }
}

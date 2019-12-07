using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Settings
{
    public float spaceshipSpeed;
    public float spaceshipReloadTimer;

    public bool adaptiveDifficultyLevel;
    public float timerToSpawnEnemy;
    public float minTimeToSpawn;
    public int changeAfterSpawn;
    public int changeSteps;

    public bool asteroid1Enable;
    public float asteroid1Speed;
    public int asteroid1Points;
    public bool asteroid2Enable;
    public float asteroid2Speed;
    public int asteroid2Points;
    public bool asteroid3Enable;
    public float asteroid3Speed;
    public int asteroid3Points;

    public bool ospaceshipEnable;
    public float ospaceshipSpeed;
    public int ospaceshipPoints;
    public int enemySpaceshipSpawnChance;
    public int enemyAsteroidsSpawnChance;

    public bool teslaEnable;
    public float teslaSpeed;
    public int teslaPoints;
    public int teslaSpawnCounter;
    public int teslaSpawnChance;
}

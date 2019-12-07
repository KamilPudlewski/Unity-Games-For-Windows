using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScoringMenu
{
    SettingsManager settingsManager;
    private static Texture2D asteroid1Texture = null;
    private static Texture2D asteroid2Texture = null;
    private static Texture2D asteroid3Texture = null;
    private static Texture2D ospaceshipTexture = null;
    private static Texture2D teslaTexture = null;

    public ScoringMenu(SettingsManager settingsManager)
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
        GUILayout.Label("Score Points Settings", EditorStyles.boldLabel);

        GUILayout.Label("Enemy Asteroids Points", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(asteroid1Texture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.asteroid1Points = EditorGUILayout.IntSlider(new GUIContent("Big Asteroid Points", "Velue Of Points After Destroy Big Asteroid"), settingsManager.settings.asteroid1Points, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(asteroid2Texture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.asteroid2Points = EditorGUILayout.IntSlider(new GUIContent("Middle Asteroid Points", "Velue Of Points After Destroy Middle Asteroid"), settingsManager.settings.asteroid2Points, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(asteroid3Texture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.asteroid3Points = EditorGUILayout.IntSlider(new GUIContent("Middle Asteroid Points", "Velue Of Points After Destroy Middle Asteroid"), settingsManager.settings.asteroid3Points, 0, 100);
        EditorGUILayout.EndHorizontal();

        GUILayout.Label("Enemy Spaceships Points", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(ospaceshipTexture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.ospaceshipPoints = EditorGUILayout.IntSlider(new GUIContent("Enemy Spaceship Points", "Velue Of Points After Destroy Enemy Spaceship"), settingsManager.settings.ospaceshipPoints, 0, 100);
        EditorGUILayout.EndHorizontal();

        GUILayout.Label("Enemy Tesla Points", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(teslaTexture, GUILayout.Width(100), GUILayout.Height(100));
        settingsManager.settings.teslaPoints = EditorGUILayout.IntSlider(new GUIContent("Enemy Tesla Points", "Velue Of Points After Destroy Enemy Tesla"), settingsManager.settings.teslaPoints, 0, 500);
        EditorGUILayout.EndHorizontal();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AdvencedMenu
{
    SettingsManager settingsManager;

    public AdvencedMenu(SettingsManager settingsManager)
    {
        this.settingsManager = settingsManager;
    }

    public void View()
    {
        GUILayout.Label("Config Path", EditorStyles.boldLabel);
        GUILayout.Label("Galaxy Ship Attack/Configs/config.binary");
    }

    private void OpenConfig()
    {
        string path = EditorUtility.OpenFilePanel("Select config file", "", "binary");
        if (path.Length != 0)
        {
            settingsManager.LoadDataFromFile(path);
        }
    }
}

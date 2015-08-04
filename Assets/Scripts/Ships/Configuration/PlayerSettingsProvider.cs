using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton for access to Player 
/// </summary>
/// 
public sealed class PlayerSettingsProvider
{
    private static readonly PlayerSettingsProvider instance = new PlayerSettingsProvider();
    
    private PlayerSettings settings;

    private PlayerSettingsProvider()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        settings = player.GetComponent<PlayerSettings>();
        Debug.Log("!!!!");
    }
    
    public static PlayerSettingsProvider Instance
    {
        get
        {
            return instance;
        }
    }

    public PlayerSettings Settings { get { return settings; } }
}


using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// AssetManager class for handling all asset loading operations within the game.
/// </summary>
public static class AssetManager
{
    private static Dictionary<string, UnityEngine.Object> assets = new Dictionary<string, UnityEngine.Object>();

    /// <summary>
    /// Loads all necessary assets for the game.
    /// </summary>
    public static void LoadAssets()
    {
        try
        {
            Logger.Log("Starting to load assets.");

            // Load monster assets
            assets.Add("MonsterModel", Resources.Load("Models/Monster"));
            assets.Add("MonsterTexture", Resources.Load("Textures/MonsterTexture"));

            // Load hunter assets
            assets.Add("HunterModel", Resources.Load("Models/Hunter"));
            assets.Add("HunterTexture", Resources.Load("Textures/HunterTexture"));

            // Load environment assets
            assets.Add("Environment", Resources.Load("Environment/Map"));

            // Load UI assets
            assets.Add("MainMenuBackground", Resources.Load("UI/MainMenuBackground"));
            assets.Add("GameHUD", Resources.Load("UI/GameHUD"));

            Logger.Log("Assets loaded successfully.");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to load assets: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Retrieves a loaded asset.
    /// </summary>
    /// <param name="assetName">The name of the asset to retrieve.</param>
    /// <returns>The loaded asset.</returns>
    public static UnityEngine.Object GetAsset(string assetName)
    {
        if (assets.TryGetValue(assetName, out UnityEngine.Object asset))
        {
            return asset;
        }
        else
        {
            Logger.LogError($"Asset not found: {assetName}");
            throw new KeyNotFoundException($"Asset not found: {assetName}");
        }
    }
}
